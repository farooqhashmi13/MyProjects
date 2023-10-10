using System.ComponentModel.DataAnnotations;

namespace ResumeBuilderLibrary.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Display(Name = "URL")]
        [MaxLength(150)]
        public string URL { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Description")]
        [MaxLength(400)]
        public string Description { get; set; }
    }
}
