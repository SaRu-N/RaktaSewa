using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models.ViewModels
{
    public class BloodStockViewModel : BloodViewModel
    {
        public int Stock_Id { get; set; }
        public bool Available { get; set; }
        public string Amount { get; set; }
        public DateTime Created_At { get; set; }

    }
    public class BloodStockCreateViewModel:BloodCreateViewModel
    {
        public int Stock_Id { get; set; }
        public bool Available { get; set; }
        public string Amount { get; set; }
    }
}
