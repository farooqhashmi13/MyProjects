namespace KnowledgeTestLibrary.Models
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int SelectedOption { get; set; }
        public bool IsRight { get; set; }
    }
}
