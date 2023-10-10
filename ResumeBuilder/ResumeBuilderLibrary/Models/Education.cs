using System.ComponentModel.DataAnnotations;

namespace ResumeBuilderLibrary.Models
{
    public class Education
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Digree Title")]
        [MaxLength(100)]
        public string DigreeTitle { get; set; }

        [Required]
        [Display(Name = "Institute")]
        [MaxLength(200)]
        public string Institute { get; set; }

        [Required]
        [Display(Name = "Grade")]
        [MaxLength(5)]
        public string Grade { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
