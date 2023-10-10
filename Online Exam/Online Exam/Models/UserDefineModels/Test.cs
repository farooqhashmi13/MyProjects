using System;

namespace Online_Exam.Models
{
    public class Test
    {
        public int Id { get; set; }
        public DateTime? TestDateTime { get; set; }
        public DateTime? TimeTaken { get; set; }
        public int? Score { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}