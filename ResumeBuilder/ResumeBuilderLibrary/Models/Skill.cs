using System.ComponentModel.DataAnnotations;

namespace ResumeBuilderLibrary.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Level")]
        public int Level { get; set; }
    }
}
