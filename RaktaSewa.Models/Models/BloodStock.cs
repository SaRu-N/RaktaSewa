using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktaSewa.Models;

namespace RaktaSewa.Models
{
    public class BloodStock: Blood
    {
        public int Stock_Id { get; set; }
        public bool Available { get; set; }
        public string Amount { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool IsDeleted { get; set; } = false;

        //public int BloodId { get; set; }
        //public string blood_group { get; set; }

        //[ForeignKey("BloodId")]
        //public virtual Blood Bloods { get; set; }



    }
}
