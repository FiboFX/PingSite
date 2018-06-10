using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingSite.Models.Host
{
    public class AddHost
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int RoomId { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
