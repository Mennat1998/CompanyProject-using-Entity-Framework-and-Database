namespace CompanyProject2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cust_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Cust_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Cust_Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Cust_Fax { get; set; }

        [Required]
        [StringLength(50)]
        public string Cust_Mobile { get; set; }

        [Required]
        [StringLength(50)]
        public string Cust_email { get; set; }

        [Required]
        [StringLength(50)]
        public string Cust_website { get; set; }
    }
}
