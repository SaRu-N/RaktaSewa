using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models
{
   public  class Admin
    {
        public int Id { get;set;}
        public int Emp_Id { get; set; }
        public string Name { get;set;}
        public string Address { get;set;}
        public string Email { get;set;}
        public string Phone_Number { get;set;}
        public DateTime Created_At { get;set;}
        public DateTime? Updated_At { get; set; }

        public bool Is_Deleted { get;set;} = false;
     
    }
}
