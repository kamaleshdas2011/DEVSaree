namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int client_id { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] time_created { get; set; }

        public int shipment_type_id { get; set; }

        public int payment_type_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string shipping_address { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string billing_address { get; set; }

        public decimal products_price { get; set; }

        public decimal delivery_cost { get; set; }

        public decimal discount { get; set; }

        public decimal final_price { get; set; }
    }
}
