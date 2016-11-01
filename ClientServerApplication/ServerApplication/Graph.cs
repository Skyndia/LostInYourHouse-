using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClientApplicationWF;

namespace ServerApplication
{
    class Graph
    {
        public List<Node> nodes { get; set; }
        public int count { get; set; }

        public Graph()
        {
            nodes = new List<Node>();
            count = 0;
        }

        /*plan is the data we received from the client. 
        * There is a list of rectangles, a list of doors, and the both points.
        * We want to build a graph from this data.
        * --We have to add every node one by one, already filled with their transitions
        * --There is one node for each door and for each point.
        */

        //je dois parcourir tous les noeuds.
        //ajouter toutes les transitions possibles à chaque fois
        //j'arrete quand je n'ai plus de noeuds non traités (utiliser une pile !)
        //Pour trouver les noeuds : j'ai les 2 avec les 2 pts, puis tous ceux des portes.
        public void Build(Blueprint plan)
        {
            //we are likely to get 16 nodes per door, and 2 node for the starting and ending points.
            int nbNode = plan.doors.Count * 16 + 2;
            PileOfNodes pile = new PileOfNodes(nbNode + 2);

            //Get the starting and arrival points
            Node aNode = new Node("start", plan.start);
            Node bNode = new Node("arrival", plan.arrival);
            pile.Add(bNode);
            pile.Add(aNode);

            //Build the graph
            while (!pile.IsEmpty())
            {
                Node currentNode = pile.Remove();
                Point currentLoc = currentNode._location;
                int currentRectIndex = plan.FindRect(currentLoc);

                if (!Has(currentNode))
                {
                    if (currentNode._type != "door")
                        currentNode.BuildABNode(plan, ref pile);
                    else
                        currentNode.BuildDoorNode(plan, ref pile);

                    Add(currentNode);
                }
            }

        }

        public void Add(Node node)
        {
            nodes.Add(node);
            count++;
        }

        //Check if node already exist in the Graph
        public bool Has(Node node)
        {
            bool res = false;
            bool proceed = true;
            int cpt = 0;
            int max = nodes.Count;

            while( cpt < max && proceed)
            {
                if (nodes.ElementAt(cpt)._location == node._location)
                {
                    proceed = false;
                    res = true;
                }
                cpt++;
            }
            return res;
        }

        
        
    }
}
