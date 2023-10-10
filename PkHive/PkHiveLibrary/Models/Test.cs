﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkHiveLibrary.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int TotalMarks { get; set; }
        public int GainedMarkes { get; set; }
        public string TimeTaken { get; set; }
        public DateTime TestDate { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public List<TestQuestion> TestQuestions { get; set; }
    }
}
