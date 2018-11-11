namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.request")]
    public partial class request
    {
        public int requestId { get; set; }

        [Column(TypeName = "bit")]
        public bool? Status { get; set; }

        public double cost { get; set; }

        [StringLength(255)]
        public string duration { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [StringLength(255)]
        public string typeressource { get; set; }

        public int? reqadmin { get; set; }

        public int? reqcl { get; set; }

        public virtual admin admin { get; set; }

        public virtual client client { get; set; }
    }
}
