namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.break")]
    public partial class _break
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public _break()
        {
            ressource1 = new HashSet<ressource>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int leaveId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        [Column(TypeName = "bit")]
        public bool isGranted { get; set; }

        [Column(TypeName = "bit")]
        public bool isTaken { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        public int? resource_userId { get; set; }

        public virtual ressource ressource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ressource> ressource1 { get; set; }
    }
}
