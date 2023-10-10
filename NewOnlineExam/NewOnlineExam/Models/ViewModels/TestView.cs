using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewOnlineExam.Models.ViewModels
{
    public class TestView
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int QuestionNo { get; set; }
    }
}