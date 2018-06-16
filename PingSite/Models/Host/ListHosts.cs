using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingSite.Models.Host
{
    public class ListHosts
    {
        public IEnumerable<HostDto> Hosts { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
