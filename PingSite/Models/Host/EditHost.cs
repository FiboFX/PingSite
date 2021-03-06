﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PingSite.Models.Host
{
    public class EditHost
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string MACAddress { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int RoomId { get; set; }
        public bool AllHosts { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
