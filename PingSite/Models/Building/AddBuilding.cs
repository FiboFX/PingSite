using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PingSite.Models.Building
{
    public class AddBuilding
    {
        [Required]
        public string Name { get; set; }
    }
}
