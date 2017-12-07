namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipment_details
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int shipment_id { get; set; }

        public int product_id { get; set; }

        public decimal quanitity { get; set; }

        public decimal price_per_unit { get; set; }

        public decimal price { get; set; }
    }
}
