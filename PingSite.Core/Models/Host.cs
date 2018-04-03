using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Host
    {
        public int Id { get; private set; }
        public string Address { get; private set; }
        public bool LastStatus { get; private set; }
        
        public Category Category { get; private set; }
        public Room Room { get; private set; }

        protected Host() { }

        protected Host(int id, string address, bool lastStatus, Category category, Room room)
        {
            Id = id;
            SetAddress(address);
            LastStatus = lastStatus;
            Category = category;
            Room = room;
        }

        public void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Address can't be empty");
            }
            Address = address;
        }
    }
}
