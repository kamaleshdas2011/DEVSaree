namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment_data
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int payment_type_id { get; set; }

        [Required]
        [StringLength(255)]
        public string data_name { get; set; }

        [Required]
        [StringLength(255)]
        public string data_type { get; set; }
    }
}
