using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Images
    {
        
        [Required]
        public int Id { get; set; }
        public string ImageUri { get; set; }
        public string Name { get; set; }
        public string BaseColour { get; set; }
        public string Caption { get; set; }
        [NotMapped]
        public Uri ImageLocation { get; set; }
    }
}
