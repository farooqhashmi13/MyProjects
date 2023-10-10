using System.ComponentModel.DataAnnotations;

namespace ResumeBuilderLibrary.Models
{
    public class Experience
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Designation")]
        [MaxLength(100)]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
