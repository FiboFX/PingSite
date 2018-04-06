using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Room
    {
        public int? Id { get; private set; }
        public string Name { get; private set; }

        public Building Building { get; private set; }

        protected Room() { }

        protected Room(int? id, string name, Building building)
        {
            Id = id;
            SetName(name);
            Building = building;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Room name can't be empty");
            }
            Name = name;
        }

        public static Room Create(int? id, string name, Building building)
            => new Room(id, name, building);
    }
}
