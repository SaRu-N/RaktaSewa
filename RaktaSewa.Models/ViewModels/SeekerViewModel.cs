using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models.ViewModels
{
   public class SeekerViewModel: CitizenViewModel
    {
        public int PatientId { get; set; }
        public string Patient_Name { get; set; }
        public string Patient_Address { get; set; }
        public int Patient_Age { get; set; }
        public string Amount { get; set; }
        public string Patient_BloodGroup { get; set; }
        public DateTime Created_At { get; set; }
    }
    public class SeekerCreateViewModel { 
        public int PatientId { get; set; }
        public string Patient_Name { get; set; }
        public string Patient_Address { get; set; }
        public int Patient_Age { get; set; }
        public string Amount { get; set; }
        public string Patient_BloodGroup { get; set; }
     
    }
}
