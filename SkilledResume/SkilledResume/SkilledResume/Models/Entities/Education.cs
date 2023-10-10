using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public string DegreeTitle { get; set; }
        public string Institute { get; set; }
        public string Grade { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
