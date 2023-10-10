using System;

namespace NewOnlineExam.Models.UserDefineModels
{
    public class Test
    {
        public int Id { get; set; }
        public DateTime? TestDateTime { get; set; }
        public string TimeTaken { get; set; }
        public int? Score { get; set; }
        public int? TotalScore { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int? SubCategoryId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}