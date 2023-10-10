using System.ComponentModel.DataAnnotations;

namespace KnowledgeTestLibrary.Models
{
    public class Option
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Statement { get; set; }
        [Required]
        public bool IsAnswer { get; set; }
    }
}
