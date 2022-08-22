﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktaSewa.Models;
namespace RaktaSewa.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [StringLength(50)]
        //[RegularExpression("[^0-9]", ErrorMessage = "Registration Number must be numeric")]
        public string Reg_No { get; set; }
        [StringLength(10)]
        //[RegularExpression("[^0-9]", ErrorMessage = "Contact Number must be numeric")]

        public string Contact { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
