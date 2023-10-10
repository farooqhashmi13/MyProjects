using System.ComponentModel.DataAnnotations;

namespace PkHiveLibrary.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Full Name*")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        [Display(Name = "Email*")]
        public string Email { get; set; }
        [MaxLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Subject*")]
        public string Subject { get; set; }
        [Required]
        [MaxLength(400)]
        [Display(Name = "Message*")]
        public string Message { get; set; }
        [Required]
        [Display(Name = "Date & Time*")]
        public DateTime SubmitDateTime { get; set; }
    }
}
