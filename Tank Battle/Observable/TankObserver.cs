using System;
using System.Collections.Generic;
using System.Text;
using Tank_Battle.Object;
using Tank_Battle.UI;

namespace Tank_Battle.Observable
{
    public class TankObserver : IObserver<Tank>
    {
        public void Update(Tank Tank)
        {
            Render.DrawTank(Tank);
        }
    }
}
