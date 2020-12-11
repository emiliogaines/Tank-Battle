using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.Object
{
    public class Tank
    {
        public Driver Driver;
        public TankFacingDirection TankDirection;
        public int Health = 10;
        public int Firepower = 1;
        public int BaseFirepower = 1;

        public int MaxHealth = 10;

        public Tank(TankFacingDirection TankDirection)
        {
            this.TankDirection = TankDirection;
        }
        public void EnterTank(Driver Driver)
        {
            this.Driver = Driver;
        }

        public int ShootAt(Tank Tank)
        {
            Firepower = BaseFirepower + new Random().Next(0, 2);
            int Damage = (Firepower + Driver.Firepower);
            Tank.Health = Math.Clamp(Tank.Health - Damage, 0, int.MaxValue);
            return Damage;
        }

        public Memento CaptureMemento()
        {
            return new Memento(Driver, Health, Firepower);
        }

        public void RestoreMemento(Memento Memento)
        {
            Driver = Memento.Driver;
            Health = Memento.Health;
            Firepower = Memento.Firepower;
        }
    }
}
