using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FeaturedItems
    {
        [Key]
        public int Image_Id { get; set; }
        public Images FeaturedImage { get; set; }
    }
}
