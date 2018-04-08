using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PingSite.Models.Room
{
    public class AddRoom
    {
        [Required]
        public string Name { get; set; }
        public int BuildingId { get; set; }
    }
}
