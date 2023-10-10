namespace NewOnlineExam.Models.UserDefineModels
{
    public class Options
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public bool IsAnswer { get; set; }
        public int QuestionId { get; set; }
        public Questions Question { get; set; }
    }
}