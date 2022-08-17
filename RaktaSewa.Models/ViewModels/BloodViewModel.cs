using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models.ViewModels
{
    public class BloodViewModel 
    {
        public int Id { get; set; }
        public string blood_group { get; set; }
    }
    public class BloodCreateViewModel
    {
        public int Id { get; set; }
        [StringLength(3)]
        public string blood_group { get; set; }
    }
}
