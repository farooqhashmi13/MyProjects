using System.ComponentModel.DataAnnotations;

namespace PkHiveLibrary.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [MaxLength(250)]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [MaxLength(400)]
        [Display(Name = "Qualification")]
        public string Qualification { get; set; }
        [MaxLength(400)]
        [Display(Name = "Experience")]
        public string Experience { get; set; }
        [MaxLength(50)]
        [Display(Name = "Pay Scale")]
        public string PayScale { get; set; }
        [Display(Name = "Vacancies")]
        public int Vacancies { get; set; }
        [Display(Name = "Posted Date")]
        public DateTime PostedDate { get; set; }
        [Required]
        [Display(Name = "Last Date")]
        public DateTime LastDate { get; set; }
        [MaxLength(400)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [MaxLength(100)]
        [Display(Name = "Apply Link")]
        public string ApplyLink { get; set; }
        [MaxLength(100)]
        [Display(Name = "Inner Link")]
        public string InnerLink { get; set; }
        [MaxLength(100)]
        [Display(Name = "Employment Type")]
        public string EmploymentType { get; set; }
        [Display(Name ="Min Salary")]
        public decimal MinSalary { get; set; }
        [Display(Name ="Max Salary")]
        public decimal MaxSalary { get; set; }
        [Display(Name = "Type")]
        public int TypeId { get; set; }
        public JobType Type { get; set; }
    }
}
