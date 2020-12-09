using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.Object
{
    public class Driver
    {
        public string Name;
        public int Firepower;
        public Driver(string Name)
        {
            this.Name = Name;
            Firepower = new Random().Next(0, 2);
        }
    }
}
