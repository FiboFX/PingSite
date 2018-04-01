using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Room
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Building Building { get; private set; }
    }
}
