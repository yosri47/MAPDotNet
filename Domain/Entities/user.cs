namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.user")]
    public partial class user
    {
        public int userId { get; set; }

        [StringLength(255)]
        public string confirmPassword { get; set; }

        [StringLength(255)]
        public string emailAddress { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string userType { get; set; }

        public virtual admin admin { get; set; }

        public virtual client client { get; set; }
    }
}
