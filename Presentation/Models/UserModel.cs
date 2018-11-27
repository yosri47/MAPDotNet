using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class UserModel
    {
        public int userId { get; set; }

        public string confirmPassword { get; set; }


        public string emailAddress { get; set; }


        public string name { get; set; }


        public string password { get; set; }


        public string userType { get; set; }

        public virtual AdminModel admin { get; set; }

        public virtual ClientModel client { get; set; }
    }
}