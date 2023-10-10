using System.ComponentModel.DataAnnotations;

namespace PkHiveLibrary.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }
        public List<Option> Options { get; set; }
    }
}