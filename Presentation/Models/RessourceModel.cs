using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class RessourceModel
    {
        public string availability { get; set; }

        public string contractType { get; set; }

        public bool? isActive { get; set; }

        public bool? isOnLeave { get; set; }

        public string note { get; set; }

        public string photo { get; set; }

        public double rate { get; set; }

        public string sector { get; set; }

        public int seniority { get; set; }


        public int userId { get; set; }





        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageModel> message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageModel> message1 { get; set; }


    }
}