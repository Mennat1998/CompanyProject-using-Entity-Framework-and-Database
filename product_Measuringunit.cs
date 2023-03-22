namespace CompanyProject2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product_Measuringunit
    {
        [Key]
        [Column("product_Measuringunit")]
        public int product_Measuringunit1 { get; set; }

        public int product_id_FK { get; set; }

        [Required]
        [StringLength(50)]
        public string product_measuretool { get; set; }

        public virtual product product { get; set; }
    }
}
