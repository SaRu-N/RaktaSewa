using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models
{
    public class Blood
    {
        public int Id { get; set; }
        [StringLength(3)]
        public string blood_group { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
