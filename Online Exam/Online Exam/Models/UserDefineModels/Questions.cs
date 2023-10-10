using System.ComponentModel.DataAnnotations;

namespace Online_Exam.Models
{
    public class Questions
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        public int CategoryId { get; set; }
        public QuestionCategory Category { get; set; }
    }
}