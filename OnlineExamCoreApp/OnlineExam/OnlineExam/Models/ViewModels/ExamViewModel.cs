using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Models.ViewModels
{
    public class ExamViewModel
    {
        public string Subject { get; set; }
        public string ExamCategory { get; set; }
        public int QuestionNo { get; set; }
        public Question Question { get; set; }
        public List<Option> Options { get; set; }
    }
}
