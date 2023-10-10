using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.Entities
{
    public class Settings
    {
        public int Id { get; set; }
        public bool Skills { get; set; }
        public bool Experience { get; set; }
        public bool Projects { get; set; }
        public bool Education { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
