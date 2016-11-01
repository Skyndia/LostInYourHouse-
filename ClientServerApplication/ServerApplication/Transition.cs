using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

/*
    A transition is a path between two points. This point can be a door, a the start, or the arrival. 
    A transition is unidirectional, and is characterized by its length, its beginning and its end.
*/

namespace ServerApplication
{
    class Transition
    {
        public Point _start { get; set; }
        public Point _end { get; set; }
        public double _length { get; set; }

        public Transition(Point start, Point end, double length)
        {
            _start = start;
            _end = end;
            _length = length;
        }
    }
}
