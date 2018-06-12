using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Host
    {
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public bool LastStatus { get; private set; }
        
        public Category Category { get; private set; }
        public Room Room { get; private set; }

        protected Host() { }

        protected Host(int? id, string name, string address, bool lastStatus, Category category, Room room)
        {
            Id = id;
            SetName(name);
            SetAddress(address);
            LastStatus = lastStatus;
            Category = category;
            Room = room;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Category name can't be empty");
            }
            Name = name;
        }

        public void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Address can't be empty");
            }
            Address = address;
        }

        public void SetLastStatus(bool status)
        {
            LastStatus = status;
        }

        public void SetCategory(Category category)
        {
            if(category != null)
            {
                Category = category;
            }
        }

        public void SetRoom(Room room)
        {
            if(room != null)
            {
                Room = room;
            }
        }

        public static Host Create(int? id, string name, string address, bool lastStatus, Category category, Room room)
            => new Host(id, name, address, lastStatus, category, room);
    }
}
