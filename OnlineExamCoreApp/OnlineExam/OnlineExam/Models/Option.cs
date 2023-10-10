using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Opt { get; set; }
        public bool IsAnswer { get; set; }
    }
}
