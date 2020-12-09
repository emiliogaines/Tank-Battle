using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.Object
{
    public class Memento
    {
        public Driver Driver;
        public int Health;
        public int Firepower;
        public Memento(Driver Driver, int Health, int Firepower)
        {
            this.Driver = Driver;
            this.Health = Health;
            this.Firepower = Firepower;
        }
    }
}
