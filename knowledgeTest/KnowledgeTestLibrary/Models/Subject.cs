using System.ComponentModel.DataAnnotations;

namespace KnowledgeTestLibrary.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public List<Question> Questions { get; set; }
        public List<Test> Tests { get; set; }
    }
}
