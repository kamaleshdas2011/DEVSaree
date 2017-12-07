namespace DataModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(64)]
        public string product_name { get; set; }

        [Required]
        [StringLength(255)]
        public string product_description { get; set; }

        public int product_type_id { get; set; }

        [Required]
        [StringLength(16)]
        public string unit { get; set; }

        public decimal price_per_unit { get; set; }

        public int PreviewImageId { get; set; }
        public virtual Images PreviewImage { get; set; }

        public virtual ICollection<Images> Images { get; set; }
    }
}
