using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int TotalMarks { get; set; }
        public int GainedMarks { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
