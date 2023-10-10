using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Models.ViewModels
{
    public class ExamsViewModel
    {
        public string i { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int SubjectId { get; set; }
        public string ExamSubject { get; set; }
        public string TotalMarks { get; set; }
        public string GainedMarks { get; set; }
        public string ExamDateS { get; set; }
        public string ExamDate { get; set; }
        public string TimeTaken { get; set; }
    }
}
