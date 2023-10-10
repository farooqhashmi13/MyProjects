using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.Entities
{
    public class JobTitles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
