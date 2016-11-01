using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    class PileOfNodes
    {
        public Node[] nodes { get; }
        public int count { get; private set; }

        public PileOfNodes(int maxSize)
        {
            nodes = new Node[maxSize];
            count = 0;
        }

        public bool Has(Node node)
        {
            bool res = false;
            int cpt = 0;
            bool proceed = true;
            while (cpt < count && proceed)
            {
                if (node._location == nodes[cpt]._location)
                {
                    proceed = false;
                    res = true;
                }
                cpt++;
            }
            return res;
        }

        public void Add(Node node)
        {
            if (!Has(node))
            {
                nodes[count] = node;
                count++;
            }
        }

        public Node Remove()
        {
            Node res = null;
            if (count > 0)
            {
                count--;
                res = nodes[count];
            }
            return res;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }
    }
}
