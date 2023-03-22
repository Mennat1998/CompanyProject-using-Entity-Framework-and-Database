namespace CompanyProject2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("permission")]
    public partial class permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public permission()
        {
            permission_product = new HashSet<permission_product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int permission_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime permission_date { get; set; }

        [Required]
        [StringLength(30)]
        public string permission_TYPE { get; set; }

        public int? store_id_FK { get; set; }

        public int? Supp_id_FK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permission_product> permission_product { get; set; }

        public virtual store store { get; set; }

        public virtual supplier supplier { get; set; }
    }
}
