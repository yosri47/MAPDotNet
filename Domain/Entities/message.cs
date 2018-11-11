namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.message")]
    public partial class message
    {
        public int messageId { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        [Column("object")]
        [StringLength(255)]
        public string _object { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? adminsend { get; set; }

        public int? clrecu { get; set; }

        public int? clsend { get; set; }

        public int? rsrecu { get; set; }

        public int? rssend { get; set; }

        public virtual admin admin { get; set; }

        public virtual client client { get; set; }

        public virtual client client1 { get; set; }

        public virtual ressource ressource { get; set; }

        public virtual ressource ressource1 { get; set; }
    }
}
