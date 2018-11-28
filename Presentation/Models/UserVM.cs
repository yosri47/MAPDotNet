using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class UserVM
    {
        public string emailAddress { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}