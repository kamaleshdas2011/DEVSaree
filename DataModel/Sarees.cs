using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    public class Sarees
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public int ColourId { get; set; }
        public virtual Colours Colour { get; set; }
        public int ImageId { get; set; }
        public virtual Images Image { get; set; }
    }
}
