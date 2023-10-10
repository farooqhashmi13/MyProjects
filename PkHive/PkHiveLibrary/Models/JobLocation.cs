using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkHiveLibrary.Models
{
    public class JobLocation
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
