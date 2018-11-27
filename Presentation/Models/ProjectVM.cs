using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ProjectVM
    {
        public int projectId { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        public int levioResources { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        public int otherResources { get; set; }

        public double profitability { get; set; }

        [StringLength(255)]
        public string projectType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        public int? organigramId { get; set; }

        public int? ownerId { get; set; }

        public bool? approved { get; set; }

        public virtual client client { get; set; }
    }
}