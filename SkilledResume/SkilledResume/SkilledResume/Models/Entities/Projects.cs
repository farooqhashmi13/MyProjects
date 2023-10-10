using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.Entities
{
    public class Projects
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectLink { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
