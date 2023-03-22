namespace CompanyProject2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Move_Of_Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Move_Of_Products_id { get; set; }

        public int from_store_id { get; set; }

        public int to_store_id { get; set; }

        public int Product_id_FK { get; set; }

        public int quantity_of_product { get; set; }

        public int supplier_id_Fk { get; set; }

        [Column(TypeName = "date")]
        public DateTime product_production_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime product_Expire_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateofMove { get; set; }

        public virtual store store { get; set; }

        public virtual store store1 { get; set; }

        public virtual product product { get; set; }

        public virtual supplier supplier { get; set; }
    }
}
