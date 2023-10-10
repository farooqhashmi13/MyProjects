namespace NewOnlineExam.Models.UserDefineModels
{
    public class TestQuestions
    {
        public int Id { get; set; }
        public Test Test { get; set; }
        public int? TestId { get; set; }
        public Questions Questions { get; set; }
        public int? QuestionsId { get; set; }
        public Options SelectedOption { get; set; }
        public int? SelectedOptionId { get; set; }
        public bool? IsCorrect { get; set; }
        public int QuestionNo { get; set; }
    }
}