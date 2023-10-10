using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Exam.Models
{
    public class Options
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public bool IsAnswer { get; set; }
        public int QuestionId { get; set; }
        public Questions Question { get; set; }
    }
}