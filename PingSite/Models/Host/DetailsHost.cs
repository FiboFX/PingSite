using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingSite.Models.Host
{
    public class DetailsHost
    {
        public HostDto Host { get; set; }
        public IEnumerable<HostHistoryDto> HostHistory { get; set; }
    }
}
