using System.ComponentModel.DataAnnotations;

namespace KnowledgeTestLibrary.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Statement { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public List<Option> Options { get; set; }
    }
}
