using KnowledgeTestLibrary.Models;

namespace knowledgeTestUI.Models
{
    public class ResultViewModel
    {
        public DateTime TestDate { get; set; }
        public List<TestQuestion> TestQuestions { get; set; }
        public string TimeTaken { get; set; }
        public int TotalMarks { get; set; }
        public int GainedMarks { get; set; }
        public string Subject { get; set; }
    }
}
