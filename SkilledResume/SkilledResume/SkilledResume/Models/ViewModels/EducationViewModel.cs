using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.View_Models
{
    public class EducationViewModel
    {
        public int EduId { get; set; }
        public string EduDegreeTitle { get; set; }
        public string EduInstitute { get; set; }
        public string EduGrade { get; set; }
        public string EduFromDate { get; set; }
        public string EduFromDateS { get; set; }
        public string EduToDate { get; set; }
        public string EduToDateS { get; set; }
        public string EduDescription { get; set; }
        public string EduUserId { get; set; }
    }
}
