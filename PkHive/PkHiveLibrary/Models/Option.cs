using System.ComponentModel.DataAnnotations;

namespace PkHiveLibrary.Models
{
    public class Option
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }
        [Required]
        public bool IsAnswer { get; set; }
    }
}