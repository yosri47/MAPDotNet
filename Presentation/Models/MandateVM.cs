using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class MandateVM
    {
      
        public bool state { get; set; }

        public double fee { get; set; }
      
        public virtual ressource resource { get; set; }

        public virtual project project { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
    
}