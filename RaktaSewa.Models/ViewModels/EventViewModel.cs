using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public string EventHost { get; set; }

        public DateTime Created_At { get; set; }
       
    }
    public class EventCreateViewModel
    {
        public int Id { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public string EventHost { get; set; }

     

    }
}
