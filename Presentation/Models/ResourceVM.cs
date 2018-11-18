using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Presentation.Models
{
    public class ResourceVM
    {
        public string name { get; set; }
        public string availability { get; set; }

        public string contractType { get; set; }

        public bool isActive { get; set; }

        public bool isOnLeave { get; set; }

        public string note { get; set; }

        public string photo { get; set; }

        public double rate { get; set; }

        public string sector { get; set; }

        public int seniority { get; set; }
        public string emailaddress { get; set; }
        public string password { get; set; }

        public int userId { get; set; }

        public int leaveId { get; set; }
        public _break leave { get; set; }

        public int mandateId { get; set; }
        public mandate mandate { get; set; }

        public int resumeId { get; set; }
        public resume resume { get; set; }

        public int projectId { get; set; }
        public project project { get; set; }

    }
}