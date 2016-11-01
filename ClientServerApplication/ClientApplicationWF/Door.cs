using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplicationWF
{
    public class Door
    {
        public int rect1 { get; set; }
        public int rect2 { get; set; }
        public Point loc1 { get; set; }
        public Point loc2 { get; set; }

        public Door()
        {
            rect1 = 0;
            rect2 = 0;
            loc1 = new Point();
            loc2 = new Point();
        }

        public Door(int r1, int r2, Point p1, Point p2)
        {
            rect1 = r1;
            rect2 = r2;
            loc1 = p1;
            loc2 = p2;
        }
    }
}
