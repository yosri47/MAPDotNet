namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.ressource")]
    public partial class ressource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ressource()
        {
            _break = new HashSet<_break>();
            mandate1 = new HashSet<mandate>();
            message = new HashSet<message>();
            message1 = new HashSet<message>();
            project1 = new HashSet<project>();
        }

        [StringLength(255)]
        public string availability { get; set; }

        [StringLength(255)]
        public string contractType { get; set; }

        public bool? isActive { get; set; }

        public bool? isOnLeave { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        public double rate { get; set; }

        [StringLength(255)]
        public string sector { get; set; }

        public int seniority { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userId { get; set; }

        public int? leaveId { get; set; }

        public int? mandateId { get; set; }

        public int? resumeId { get; set; }

        public int? projectId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_break> _break { get; set; }

        public virtual _break break1 { get; set; }

        public virtual mandate mandate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandate1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> message1 { get; set; }

        public virtual project project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> project1 { get; set; }
    }
}
