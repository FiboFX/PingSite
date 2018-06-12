using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.DTO
{
    public class HostDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool LastStatus { get; set; }
        public int? CategoryId { get; set; }
    }
}
