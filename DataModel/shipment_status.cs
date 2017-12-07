namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipment_status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int shipment_id { get; set; }

        public int status_catalog_id { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] status_time { get; set; }

        [Column(TypeName = "text")]
        public string notes { get; set; }
    }
}
