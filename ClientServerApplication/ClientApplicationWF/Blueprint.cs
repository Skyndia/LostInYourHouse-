extern alias Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Jconverter = Converter.Newtonsoft.Json.JsonConvert;

namespace ClientApplicationWF
{
    public class Blueprint
    {
        public List<Rectangle> rooms { get; set; }
        public List<Door> doors { get; set; }
        public Point start { get; set; }
        public Point arrival { get; set; }

        public Blueprint()
        {

        }

        public Blueprint(string json)
        {
            Blueprint plan = Jconverter.DeserializeObject<Blueprint>(json);
            rooms = plan.rooms;
            doors = plan.doors;
            start = plan.start;
            arrival = plan.arrival;
        }

        public Blueprint(List<Rectangle> rectangles, List<Door> gates, Point aPoint, Point bPoint)
        {
            rooms = rectangles;
            doors = gates;
            start = aPoint;
            arrival = bPoint;
        }

        //find the owner of the p point
        public int FindRect(Point p)
        {
            int res = -1;
            bool proceed = true;
            int cpt = 0;
            int n = rooms.Count;

            while (cpt < n && proceed)
            {
                Rectangle rect = rooms.ElementAt(cpt);
                if (rect.X < p.X && p.X < rect.X + rect.Width)
                    if (rect.Y < p.Y && p.Y < rect.Y + rect.Height)
                    {
                        proceed = false; //exit the loop
                        res = cpt; //get the index of the rectangle whose contains the p point.
                    }
                cpt++;
            }

            //return -1 if not found.
            return res;
        }

        override
        public string ToString()
        {
            return Jconverter.SerializeObject(this);
        }
    }
}
