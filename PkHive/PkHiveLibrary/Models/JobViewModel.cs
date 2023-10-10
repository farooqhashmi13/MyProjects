using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkHiveLibrary.Models
{
    public class JobViewModel
    {
        public Job Job { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}
