using System.ComponentModel.DataAnnotations;

namespace Online_Exam.Models
{
    public class Contact
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

    }
}