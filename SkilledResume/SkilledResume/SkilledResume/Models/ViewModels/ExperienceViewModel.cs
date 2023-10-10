using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkilledResume.Models.View_Models
{
    public class ExperienceViewModel
    {
        public int ExpId { get; set; }
        public string ExpCompanyName { get; set; }
        public string ExpJobTitile { get; set; }
        public string ExpFromDate { get; set; }
        public string ExpFromDateS { get; set; }
        public string ExpToDate { get; set; }
        public string ExpToDateS { get; set; }
        public string ExpDescription { get; set; }
        public string ExpUserId { get; set; }
    }
}
