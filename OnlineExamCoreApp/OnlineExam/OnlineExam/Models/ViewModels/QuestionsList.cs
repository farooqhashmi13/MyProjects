using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Models.ViewModels
{
    public class QuestionsList
    {
        public string i { get; set; }
        public Question Question { get; set; }
        public List<Option> Options { get; set; }
    }
}
