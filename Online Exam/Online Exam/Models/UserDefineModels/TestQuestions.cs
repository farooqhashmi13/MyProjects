namespace Online_Exam.Models
{
    public class TestQuestions
    {
        public int Id { get; set; }
        public Test Test { get; set; }
        public int? TestId { get; set; }
        public Questions Questions { get; set; }
        public int? QuestionsId { get; set; }
        public int? OptionId { get; set; }
        public Options Option { get; set; }
        public string Result { get; set; }
    }
}