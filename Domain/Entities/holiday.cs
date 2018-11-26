namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.holiday")]
    public partial class holiday
    {
        public int holidayId { get; set; }

        [Column(TypeName = "date")]
        public DateTime endDate { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime startDate { get; set; }
    }
}
