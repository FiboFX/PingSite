using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class HostHistory
    {
        public int? Id { get; set; }
        public DateTime DateOnline { get; set; }

        public Host Host { get; set; }

        protected HostHistory() { }

        private HostHistory(int? id, DateTime dateOnline, Host host)
        {
            Id = id;
            DateOnline = dateOnline;
            Host = host;
        }

        public static HostHistory Create(int? id, DateTime dateOnline, Host host)
            => new HostHistory(id, dateOnline, host);
    }
}
