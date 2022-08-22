using RaktaSewa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace RaktaSewa.Models
{
    public class Donor : Citizen
    {
       public string Amount { get; set; }
       public bool isEligible { get; set; }
        public int EventId { get; set; }
        public int HospitalId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("EventId")]
        public virtual Event Events { get; set; }
        [ForeignKey("HospitalId")]
        public virtual Hospital Hospitals { get; set; }


    }
}
