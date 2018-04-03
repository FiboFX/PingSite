using System;
using System.Collections.Generic;
using System.Text;

namespace PingSite.Core.Models
{
    public class Building
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        protected Building() { }

        protected Building(int id, string name)
        {
            Id = id;
            SetName(name);
        }

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Building name can't be empty");
            }
            Name = name;
        }

        public static Building Create(int id, string name)
            => new Building(id, name);
    }
}
