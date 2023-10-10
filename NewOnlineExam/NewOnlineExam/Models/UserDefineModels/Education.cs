using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewOnlineExam.Models.UserDefineModels
{
    public class Education
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string Description { get; set; }
    }
}