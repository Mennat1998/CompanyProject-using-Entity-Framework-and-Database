namespace CompanyProject2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            Move_Of_Products = new HashSet<Move_Of_Products>();
            permission_product = new HashSet<permission_product>();
            product_Measuringunit = new HashSet<product_Measuringunit>();
            store_Product = new HashSet<store_Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string product_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime product_production_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime product_Expire_date { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? validationperiod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Move_Of_Products> Move_Of_Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permission_product> permission_product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product_Measuringunit> product_Measuringunit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<store_Product> store_Product { get; set; }
    }
}
