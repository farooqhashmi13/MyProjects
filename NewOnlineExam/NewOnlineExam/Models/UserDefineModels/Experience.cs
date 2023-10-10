using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewOnlineExam.Models.UserDefineModels
{
    public class Experience
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}