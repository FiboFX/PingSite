using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Host
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public bool LastStatus { get; set; }
        
        public Category Category { get; set; }
        public Room Room { get; set; }
    }
}
