using EmirhanAvci.Project.BusinessLayer.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _mailSender;

        public EmailController(IEmailSender mailSender)
        {
            _mailSender = mailSender;
        }

        [HttpGet]
        public async Task<ActionResult> SendMail()
        {
            await _mailSender.SendEmailAsync("kubilaykapl41@gmail.com", "Konu", "Mesaj gönderildi");
            return Ok();
        }
    }
}
