using System.ComponentModel.DataAnnotations;

namespace KnowledgeTestViews.Models
{
    public class Contact
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength (250)]
        public string Message { get; set; }
    }
}
