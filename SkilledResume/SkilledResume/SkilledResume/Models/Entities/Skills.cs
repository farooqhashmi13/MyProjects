using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.Entities
{
    public class Skills
    {
        public int Id { get; set; }
        public string Skill { get; set; }
        public int Level { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
