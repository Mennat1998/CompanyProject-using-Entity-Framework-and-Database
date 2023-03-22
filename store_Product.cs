namespace CompanyProject2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class store_Product
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int store_id_FK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_id_FK { get; set; }

        public int quantity_of_product { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Dateofinsertinstore { get; set; }

        public virtual product product { get; set; }

        public virtual store store { get; set; }
    }
}
