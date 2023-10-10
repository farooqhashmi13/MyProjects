using System.ComponentModel.DataAnnotations;

namespace PkHiveLibrary.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Location")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Display(Name ="City")]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [Display(Name ="ZipCode")]
        [MaxLength(100)]
        public string ZipCode { get; set; }
    }
}
