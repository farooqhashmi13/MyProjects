using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Models.ViewModels
{
    public class ResultViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
        public string TotalMarks { get; set; }
        public string GainedMarks { get; set; }
    }
}
