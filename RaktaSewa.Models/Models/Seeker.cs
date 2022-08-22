using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktaSewa.Models;
namespace RaktaSewa.Models
{
   public class Seeker: Citizen
    {
        public int PatientId { get; set; }
        public string Patient_Name { get; set; }
        public string Patient_Address { get; set; }
        public int Patient_Age { get; set; }
        public string Amount { get; set; }
        public string Patient_BloodGroup { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
