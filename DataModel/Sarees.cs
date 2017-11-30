using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class Sarees
    {
        [Required]
        public int Id { get; set; }
        public Material Material { get; set; }
        public Colours Colour { get; set; }
        public Images Image { get; set; }
    }
}
