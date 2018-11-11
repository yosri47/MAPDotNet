namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.organigram")]
    public partial class organigram
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public organigram()
        {
            project = new HashSet<project>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int organigramId { get; set; }

        [StringLength(255)]
        public string accountManager { get; set; }

        [StringLength(255)]
        public string assignementManager { get; set; }

        [StringLength(255)]
        public string managementLevel { get; set; }

        [StringLength(255)]
        public string programName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> project { get; set; }
    }
}
