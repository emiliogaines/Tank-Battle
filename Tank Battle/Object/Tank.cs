using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.Object
{
    public class Tank
    {
        public Driver driver;
        public int health = 10;
        public int firepower = 1;

        public void EnterTank(Driver driver)
        {
            this.driver = driver;
        }

        public void ShootAt(Tank tank)
        {
            tank.health = Math.Clamp(tank.health - this.firepower, 0, int.MaxValue); 
        }
    }
}
