﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.DTO
{
    public class HostDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MACAddress { get; set; }
        public bool LastStatus { get; set; }
        
        public CategoryDto Category { get; set; }
        public RoomDto Room { get; set; }
    }
}
