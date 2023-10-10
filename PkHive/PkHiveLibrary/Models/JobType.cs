using System.ComponentModel.DataAnnotations;

namespace PkHiveLibrary.Models
{
    public class JobType
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
