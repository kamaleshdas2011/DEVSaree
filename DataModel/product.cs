using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Product
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

        public string all_image_ids { get; set; }
        public string all_vendors { get; set; }
        [NotMapped]
        public virtual List<Vendor> Vendors { get; set; }
        [NotMapped]
        public List<Images> all_images { get; set; }
    }
}
