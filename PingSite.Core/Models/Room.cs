﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Building Building { get; set; }
    }
}
