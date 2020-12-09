using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.UI
{
    public class Option
    {
        public string title;
        public int x, y;
        public int realPositionX, realPositionY;
        public Option(string title, int x = 0, int y = 0)
        {
            this.title = title;
            this.x = x;
            this.y = y;
        }

        public void SetRealPosition(int x, int y)
        {
            realPositionX = x;
            realPositionY = y;
        }
    }
}
