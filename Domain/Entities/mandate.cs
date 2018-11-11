namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.mandate")]
    public partial class mandate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mandate()
        {
            ressource = new HashSet<ressource>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mandateId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        public double fee { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        public int? projectId { get; set; }

        public int resourceId { get; set; }

        [Column(TypeName = "bit")]
        public bool? state { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ressource> ressource { get; set; }

        public virtual project project { get; set; }

        public virtual ressource ressource1 { get; set; }
    }
}
