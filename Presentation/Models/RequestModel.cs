using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class RequestModel
    {
        public int requestId { get; set; }
        public bool status { get; set; }

        public double cost { get; set; }

        public string duration { get; set; }

        public DateTime endDate { get; set; }

        public DateTime startDate { get; set; }

        public string typeressource { get; set; }

        public AdminModel reqadmin { get; set; }

        public ClientModel reqcl { get; set; }
    }
}