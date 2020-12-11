using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.Object
{
    public class Checkpoint
    {
        TankMemory TankMemory;
        public void SaveCheckpoint(Tank tank)
        {
            if (TankMemory == null)
            {
                TankMemory = new TankMemory();
            }

            TankMemory.Memento = tank.CaptureMemento();
            
        }

        public bool RestoreCheckpoint(Tank Tank)
        {
            if (TankMemory != null)
            {
                Tank.RestoreMemento(TankMemory.Memento);
            }
            return (TankMemory != null);
        }
    }
}
