namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_id { get; set; }

        public decimal in_stock { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] last_update_time { get; set; }
    }
}
