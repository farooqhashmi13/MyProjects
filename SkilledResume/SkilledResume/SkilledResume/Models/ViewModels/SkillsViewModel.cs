using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.View_Models
{
    public class SkillsViewModel
    {
        public int SkId { get; set; }
        public string SkSkill { get; set; }
        public int SkLevel { get; set; }
        public string SkUserId { get; set; }
    }
}
