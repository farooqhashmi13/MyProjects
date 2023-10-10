using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string JobTitile { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
