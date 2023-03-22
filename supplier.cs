namespace CompanyProject2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("supplier")]
    public partial class supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public supplier()
        {
            Move_Of_Products = new HashSet<Move_Of_Products>();
            permissions = new HashSet<permission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Supp_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Supp_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Supp_Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Supp_Fax { get; set; }

        [Required]
        [StringLength(50)]
        public string Supp_Mobile { get; set; }

        [Required]
        [StringLength(50)]
        public string Supp_email { get; set; }

        [Required]
        [StringLength(50)]
        public string Supp_website { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Move_Of_Products> Move_Of_Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permission> permissions { get; set; }
    }
}
