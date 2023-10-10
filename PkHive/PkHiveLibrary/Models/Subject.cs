using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkHiveLibrary.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public List<Question> Questions { get; set; }
    }
}
