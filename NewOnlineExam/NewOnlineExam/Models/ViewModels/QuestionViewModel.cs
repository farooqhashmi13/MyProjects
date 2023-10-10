using NewOnlineExam.Models.UserDefineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewOnlineExam.Models.ViewModels
{
    public class QuestionViewModel
    {
        public int CategoryId { get; set; }
        public SubCategory Category { get; set; }
        public string Question { get; set; }
        public Questions Questions { get; set; }
        public Options[] Options { get; set; }
        public bool IsAnswered { get; set; }
        public int QuestionNo { get; set; }
    }
}