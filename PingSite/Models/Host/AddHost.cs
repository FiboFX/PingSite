using PingSite.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PingSite.Models.Host
{
    public class AddHost
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string MACAddress { get; set; }
        public int RoomId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
