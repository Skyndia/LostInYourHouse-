using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ServerApplication
{
    class Dijkstra
    {
        public int[] _predecesseurs { get; private set; }
        public double[] _distances { get; private set; }
        public int _nbNode { get; private set; }
        private List<Node> _Visited { get; set; }
        private List<Node> _Unvisited { get; set; }
        private int _sDeb { get; set; }
        private Graph _graph { get; set; }

        public Dijkstra(Graph graph)
        {
            _nbNode = graph.nodes.Count;
            _predecesseurs = new int[_nbNode];
            _distances = new double[_nbNode];
            _graph = graph;

            _Visited = new List<Node>();
            _Unvisited = new List<Node>(_graph.nodes);

            _sDeb = graph.nodes.FindIndex(n => n._type == "start");
        }

        //-1 means +infinite

        private void Initialize()
        {
            for (int i = 0; i < _nbNode; i++)
                _distances[i] = -1;
            _distances[_sDeb] = 0;
        }

        private int Trouve_min()
        {
            int res = -1;
            double mini = -1;

            for(int i = 0; i < _Unvisited.Count; i++)
            {
                if (_Unvisited.ElementAt(i) != null)
                {
                    if (_distances[i] != -1)
                    {
                        if (mini == -1 || mini != -1 && _distances[i] < mini)
                        {
                            mini = _distances[i];
                            res = i;
                        }
                    }
                }
                
            }
            return res;
        }

        private void Maj_Distances(int s1, int s2)
        {
            Node ns1 = _graph.nodes.ElementAt(s1);
            Node ns2 = _graph.nodes.ElementAt(s2);
            Transition s1s2 = ns1._transitions.Find(t => t._end == ns2._location);
            double weight = s1s2._length;

            if (_distances[s1] != -1 )
            {
                if (_distances[s2] == -1 || _distances[s2] > _distances[s1] + weight)
                {
                    _distances[s2] = _distances[s1] + weight;
                    _predecesseurs[s2] = s1;
                }
            }
        }

        public void Run()
        {
            Initialize();
            int nbNodeRemoved = 0;

            while (_Unvisited.Count != nbNodeRemoved)
            {
                int s1 = Trouve_min();
                _Unvisited.RemoveAt(s1);
                _Unvisited.Insert(s1, null);
                nbNodeRemoved++;

                //Foreach s2 close to s1
                Node ns1 = _graph.nodes.ElementAt(s1);
                foreach (Transition trans in ns1._transitions)
                {
                    Point p = trans._end;
                    int s2 = _graph.nodes.FindIndex(n => n._location == p);
                    Maj_Distances(s1, s2);
                }
            }
        }

        public List<Point> GetResult()
        {
            List<Point> solution = new List<Point>();
            int s = _graph.nodes.FindIndex(n => n._type == "arrival");
            int sDeb = _graph.nodes.FindIndex(n => n._type == "start");

            while (s != sDeb)
            {
                solution.Insert(0, _graph.nodes.ElementAt(s)._location);
                s = _predecesseurs[s];
            }
            solution.Insert(0, _graph.nodes.ElementAt(sDeb)._location);
            return solution;
        }
    }
}
