using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Quest { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
