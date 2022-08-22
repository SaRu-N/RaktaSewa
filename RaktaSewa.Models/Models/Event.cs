using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models
{
   public class Event
    {
        public int Id { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public string EventHost { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool IsDeleted { get; set; } =false;
    }
}
