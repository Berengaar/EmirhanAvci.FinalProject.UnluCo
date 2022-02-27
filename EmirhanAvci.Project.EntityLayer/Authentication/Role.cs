using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Authentication
{
    public class Role:IdentityRole<int>
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
