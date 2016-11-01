using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApplicationWF;
using System.Drawing;

namespace ServerApplication
{
    class Node
    {
        public string _type { get; set; } // "door" or "start" or "arrival"
        public List<Transition> _transitions { get; set; }
        public Point _location { get; set; } // this is 'Where we are'. It's the index of the room which this node embodies.
        public Door _data { get; set; }

        public Node(string type, Point pos)
        {
            _type = type;
            _transitions = new List<Transition>();
            _location = pos;
        }

        public Node(string type, List<Transition> transitions, Point location)
        {
            _type = type;
            _transitions = transitions;
            _location = location;
        }

        public void Add_Transition(Transition newTransition)
        {
            _transitions.Add(newTransition);
        }


        public bool IsDeparture()
        {
            return _type == "start";
        }

        public bool IsArrival()
        {
            return _type == "arrival";
        }

        public bool IsDoor()
        {
            return _type == "door";
        }

        public void BuildABNode(Blueprint plan, ref PileOfNodes pile)
        {
            int currentRectIndex = plan.FindRect(_location);
            //Get the number of the room where the arrival point is
            int indexRoomB = plan.FindRect(plan.arrival);

            //We have to work only if the node is not already in the graph
            //For each door
            foreach (Door door in plan.doors)
            {
                //If the door is connected to the current room
                if (door.rect1 == currentRectIndex || door.rect2 == currentRectIndex)
                {
                    //then we have to create some nodes with this doors, and add the transitions
                    //The difficulty is that we want different nodes for one door, depending on the size of this door

                    //get the interval (a door is only horizontal or vertical)
                    bool isVertical = Math.Abs(door.loc1.X - door.loc2.X) < Math.Abs(door.loc1.Y - door.loc2.Y);
                    int interval = Math.Max(Math.Abs(door.loc1.X - door.loc2.X), Math.Abs(door.loc1.Y - door.loc2.Y));

                    //get the step
                    int step = 5;
                    if (interval / step > 15) step = interval / 15; //Max 15 nodes per door
                     //loop
                    int i = 0;
                    for (i = 0; i < interval; i = i + step)
                    {
                        Point newPos = new Point();
                        if (isVertical) newPos = new Point(door.loc1.X, door.loc1.Y + i);
                        else newPos = new Point(door.loc1.X + i, door.loc1.Y);

                        //Add the node to the pile
                        Node nodeToAdd = new Node("door", newPos);
                        nodeToAdd._data = door;
                        pile.Add(nodeToAdd);

                        //Add the transitions to the current node
                        Transition newTransition;
                        //Calculate the length of the transition
                        double distance = Math.Sqrt((newPos.X - _location.X) * (newPos.X - _location.X)
                                                + (newPos.Y - _location.Y) * (newPos.Y - _location.Y));
                        newTransition = new Transition(_location, newPos, distance);

                        //Add the transition to the current node
                        Add_Transition(newTransition);

                    }
                    //add an iteration for i == interval
                    Node toAdd = new Node("door", door.loc2);
                    toAdd._data = door;
                    pile.Add(toAdd);

                    //Add the transitions to the current node
                    Transition newT;
                    //Calculate the length of the transition
                    double d = Math.Sqrt((door.loc2.X - _location.X) * (door.loc2.X - _location.X)
                                            + (door.loc2.Y - _location.Y) * (door.loc2.Y - _location.Y));
                    newT = new Transition(_location, door.loc2, d);

                    //Add the transition to the current node
                    Add_Transition(newT);
                }
            }
            //Now we have to see if we can reach the B point
            if (currentRectIndex == indexRoomB)
            {
                //in this case, add the corresponding transition
                Transition toB;
                //Calculate the length of the transition
                double d = Math.Sqrt((plan.arrival.X - _location.X) * (plan.arrival.X - _location.X)
                                        + (plan.arrival.Y - _location.Y) * (plan.arrival.Y - _location.Y));
                toB = new Transition(_location, plan.arrival, d);

                //Add the transition to the current node
                Add_Transition(toB);
            }
        }

        public void BuildDoorNode(Blueprint plan, ref PileOfNodes pile)
        {
            //Get the number of the room where the arrival point is
            int indexRoomB = plan.FindRect(plan.arrival);

            //For each door
            foreach (Door door in plan.doors)
            {
                //If the door is connected to the current room
                if (door.rect1 == _data.rect1 || door.rect1 == _data.rect2 ||
                    door.rect2 == _data.rect1 || door.rect2 == _data.rect2)
                {
                    //then we have to create some nodes with this doors, and add the transitions
                    //The difficulty is that we want different nodes for one door, depending on the size of this door

                    //get the interval (a door is only horizontal or vertical)
                    bool isVertical = Math.Abs(door.loc1.X - door.loc2.X) < Math.Abs(door.loc1.Y - door.loc2.Y);
                    int interval = Math.Max(Math.Abs(door.loc1.X - door.loc2.X), Math.Abs(door.loc1.Y - door.loc2.Y));

                    //get the step
                    int step = 5;
                    if (interval / step > 15) step = interval / 15; //Max 15 nodes per door

                    //loop
                    int i = 0;
                    for (i = 0; i < interval; i = i + step)
                    {
                        Point newPos = new Point();
                        if (isVertical) newPos = new Point(door.loc1.X, door.loc1.Y + i);
                        else newPos = new Point(door.loc1.X + i, door.loc1.Y);

                        //Add the node to the pile
                        Node nodeToAdd = new Node("door", newPos);
                        nodeToAdd._data = door;
                        pile.Add(nodeToAdd);

                        //Add the transitions to the current node
                        Transition newTransition;
                        //Calculate the length of the transition
                        double distance = Math.Sqrt((newPos.X - _location.X) * (newPos.X - _location.X)
                                                + (newPos.Y - _location.Y) * (newPos.Y - _location.Y));
                        newTransition = new Transition(_location, newPos, distance);

                        //Add the transition to the current node
                        Add_Transition(newTransition);

                    }
                    //add an iteration for i == interval
                    Node toAdd = new Node("door", door.loc2);
                    toAdd._data = door;
                    pile.Add(toAdd);

                    //Add the transitions to the current node
                    Transition newT;
                    //Calculate the length of the transition
                    double d = Math.Sqrt((door.loc2.X - _location.X) * (door.loc2.X - _location.X)
                                            + (door.loc2.Y - _location.Y) * (door.loc2.Y - _location.Y));
                    newT = new Transition(_location, door.loc2, d);

                    //Add the transition to the current node
                    Add_Transition(newT);
                }
            }
            //Now we have to see if we can reach the B point
            if (_data.rect1 == indexRoomB || _data.rect2 == indexRoomB)
            {
                //in this case, add the corresponding transition
                Transition toB;
                //Calculate the length of the transition
                double d = Math.Sqrt((plan.arrival.X - _location.X) * (plan.arrival.X - _location.X)
                                        + (plan.arrival.Y - _location.Y) * (plan.arrival.Y - _location.Y));
                toB = new Transition(_location, plan.arrival, d);

                //Add the transition to the current node
                Add_Transition(toB);
            }
        }
    }
}
