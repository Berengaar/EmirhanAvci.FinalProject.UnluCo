using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using EmirhanAvci.Project.EntityLayer.Authentication;
using EmirhanAvci.Project.EntityLayer.Authentication.Models;
using System.Security.Claims;
using EmirhanAvci.Project.EntityLayer.Authentication.Messages;

namespace EmirhanAvci.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _user;
        private readonly RoleManager<Role> _role;
        private readonly IConfiguration _configuration;
        public AuthenticateController(UserManager<User> user, RoleManager<Role> role, IConfiguration configuration)
        {
            _user = user;
            _role = role;
            _configuration = configuration;
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _user.FindByNameAsync(model.Username);
            if (user != null && await _user.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _user.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _user.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response {  Message = RegisterMessage.UserExists });
            }

            else
            {
                User user = new User()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username
                };
                var result = await _user.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = RegisterMessage.IsValid });
                }
                else
                {
                    return Ok(new Response { Message = RegisterMessage.UserAdded });
                }
            }
        }

        [HttpPost("/RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _user.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = RegisterMessage.UserExists });
            }
            else
            {
                User user = new User()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username
                };
                var result = await _user.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = RegisterMessage.UserExists });
                }

                if (!await _role.RoleExistsAsync(Role.Admin))
                {
                    await _role.CreateAsync(new Role());
                }
                if (!await _role.RoleExistsAsync(Role.User))
                {
                    await _role.CreateAsync(new Role());
                }

                if (await _role.RoleExistsAsync(Role.Admin))
                {
                    await _user.AddToRoleAsync(user, Role.Admin);
                }
                return Ok(new Response { Message = RegisterMessage.UserExists });
            }
           
        }
    }
}
