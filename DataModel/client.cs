namespace DataModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string first_name { get; set; }

        [Required]
        [StringLength(128)]
        public string last_name { get; set; }

        [StringLength(128)]
        public string company_name { get; set; }

        [StringLength(64)]
        public string VAT_ID { get; set; }

        public int city_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string client_address { get; set; }
    }
}
