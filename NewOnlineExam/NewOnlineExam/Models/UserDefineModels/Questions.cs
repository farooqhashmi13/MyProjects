namespace NewOnlineExam.Models.UserDefineModels
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int CategoryId { get; set; }
        public SubCategory subCategory { get; set; }
    }
}