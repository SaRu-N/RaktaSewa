using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Model
{
   public class Citizen
    {
        [Key]
        public int citizen_id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Address { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        [StringLength(3)]
        public string blood_group { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string photo { get; set; }
        [Required]
        [StringLength(20)]
        public string Citizenship_No { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
