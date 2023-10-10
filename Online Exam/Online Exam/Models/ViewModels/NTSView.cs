using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Exam.Models
{
    public class NTSView
    {
        public IEnumerable<Questions> Portion1 { get; set; }
        public IEnumerable<Questions> Portion2 { get; set; }
        public IEnumerable<Questions> Portion3 { get; set; }
        public IEnumerable<Questions> Portion4 { get; set; }
    }
}