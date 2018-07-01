using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PingSite.Core.DTO
{
    public class Settings
    {
        public bool AutoPing { get; set; }
        [Range(1, 59)]
        public string AutoPingDelay { get; set; }
    }
}
