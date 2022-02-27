using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Authentication.Messages
{
    public class RegisterMessage
    {
        public const string UserExists = "User already exist";
        public const string UserAdded = "User successfully added on the system";
        public const string IsValid = "Please enter valid password and email";
    }
}
