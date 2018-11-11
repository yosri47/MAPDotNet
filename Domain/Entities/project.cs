namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.project")]
    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            mandate = new HashSet<mandate>();
            ressource = new HashSet<ressource>();
            skill = new HashSet<skill>();
            ressource1 = new HashSet<ressource>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandate { get; set; }

        public virtual organigram organigram { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ressource> ressource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skill> skill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ressource> ressource1 { get; set; }
    }
}
