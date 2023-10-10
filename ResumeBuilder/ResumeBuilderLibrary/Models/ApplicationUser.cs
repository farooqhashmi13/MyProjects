using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilderLibrary.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(2)]
        [Display(Name = "Age")]
        public string Age { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; } = new DateTime();

        [Required]
        [MaxLength(50)]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Display(Name = "Country")]
        public string Country { get; set; } = string.Empty;
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Project> Projects { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
