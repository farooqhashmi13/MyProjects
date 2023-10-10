using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.View_Models
{
    public class ProjectsViewModel
    {
        public int ProjId { get; set; }
        public string ProjProjectTitle { get; set; }
        public string ProjProjectLink { get; set; }
        public string ProjStartDate { get; set; }
        public string ProjStartDateS { get; set; }
        public string ProjEndDate { get; set; }
        public string ProjEndDateS { get; set; }
        public string ProjDescription { get; set; }
        public string ProjUserId { get; set; }
    }
}
