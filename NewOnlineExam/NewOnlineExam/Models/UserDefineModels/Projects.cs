using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewOnlineExam.Models.UserDefineModels
{
    public class Projects
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}