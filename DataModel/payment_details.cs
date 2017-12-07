namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment_details
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int shipment_id { get; set; }

        public int payment_data_id { get; set; }

        [Required]
        [StringLength(255)]
        public string value { get; set; }
    }
}
