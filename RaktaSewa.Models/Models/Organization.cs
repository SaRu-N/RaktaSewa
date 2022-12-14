using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models
{
 public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Address { get; set; }
        public string Contact { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
