using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktaSewa.Models.ViewModels
{
    public class OrganizationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Address { get; set; }
        public string Contact { get; set; }
        public DateTime Created_At { get; set; }
    }
    public class OrganizationCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Address { get; set; }
        public string Contact { get; set; }
        
    }
}
