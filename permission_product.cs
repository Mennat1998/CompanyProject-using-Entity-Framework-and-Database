namespace CompanyProject2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class permission_product
    {
        [Key]
        public int permission_product_id { get; set; }

        public int Product_id_FK { get; set; }

        public int quantity_of_product { get; set; }

        public int? permission_id_FK { get; set; }

        public virtual permission permission { get; set; }

        public virtual product product { get; set; }
    }
}
