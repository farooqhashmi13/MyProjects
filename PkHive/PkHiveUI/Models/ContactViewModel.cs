using System.ComponentModel.DataAnnotations;

namespace PkHiveUI.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100)]
        [Display(Name = "Full Name*")]
        public string FullName { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [MaxLength(100)]
        [Display(Name = "Email*")]
        public string Email { get; set; }
       
        [MaxLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
       
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100)]
        [Display(Name = "Subject*")]
        public string Subject { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(400)]
        [Display(Name = "Message*")]
        public string Message { get; set; }
    }
}
