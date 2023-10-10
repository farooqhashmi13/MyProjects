using System.ComponentModel.DataAnnotations;

namespace Online_Exam.Models
{
    public class TestView
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
    }
}