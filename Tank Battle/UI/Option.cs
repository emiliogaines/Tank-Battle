using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.UI
{
    public class Option
    {
        public string Title;
        public int X, Y;
        public int RealPositionX, RealPositionY;
        public Option(string Title, int X = 0, int Y = 0)
        {
            this.Title = Title;
            this.X = X;
            this.Y = Y;
        }

        public void SetRealPosition(int x, int y)
        {
            RealPositionX = x;
            RealPositionY = y;
        }
    }
}
