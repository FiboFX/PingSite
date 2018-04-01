using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Host
    {
        public int Id { get; private set; }
        public string Address { get; private set; }
        public bool LastStatus { get; private set; }
        
        public Category Category { get; private set; }
        public Room Room { get; private set; }
    }
}
