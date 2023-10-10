using System.Collections.Generic;

namespace Online_Exam.Models.ViewModels
{
    public class QuestionViewModel
    {
        public int CategoryId { get; set; }
        public QuestionCategory Category { get; set; }
        public string Question { get; set; }
        public Questions Questions { get; set; }
        public Options[] Options { get; set; }
        public bool IsAnswered { get; set; }

        //    public string Option1 { get; set; }
        //    public bool Option1IsAnswer { get; set; }
        //    public string Option2 { get; set; }
        //    public bool Option2IsAnswer { get; set; }
        //    public string Option3 { get; set; }
        //    public bool Option3IsAnswer { get; set; }
        //    public string Option4 { get; set; }
        //    public bool Option4IsAnswer { get; set; }
    }
}