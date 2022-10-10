using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    // GraphALNode 클래스
    public class GraphALNode<T>
    {
        private List<GraphALNode<T>> _neighbors;
        private List<int> _weights;

        public T Data { get; set; }

        public GraphALNode()
        {
        }

        public GraphALNode(T value)
        {
            this.Data = value;
        }

        public List<GraphALNode<T>> Neighbors
        {
            get
            {
                _neighbors = _neighbors ?? new List<GraphALNode<T>>();
                return _neighbors;
            }
        }

        public List<int> Weights
        {
            get
            {
                _weights = _weights ?? new List<int>();
                return _weights;
            }
        }
    }

    // GraphAL 클래스
    public class GraphAL<T>
    {
        private List<GraphALNode<T>> _nodeList;

        public GraphAL()
        {
            _nodeList = new List<GraphALNode<T>>();
        }

        public GraphALNode<T> AddNode(T data)
        {
            GraphALNode<T> n = new GraphALNode<T>(data);
            _nodeList.Add(n);
            return n;
        }

        public GraphALNode<T> AddNode(GraphALNode<T> node)
        {
            _nodeList.Add(node);
            return node;
        }

        public void AddEdge(GraphALNode<T> from, GraphALNode<T> to, bool oneway = true, int weight = 0)
        {
            from.Neighbors.Add(to);
            from.Weights.Add(weight);

            if (!oneway)
            {
                to.Neighbors.Add(from);
                to.Weights.Add(weight);
            }
        }

        internal void DebugPrintLinks()
        {
            foreach (GraphALNode<T> GraphALNode in _nodeList)
            {
                foreach (var n in GraphALNode.Neighbors)
                {
                    string s = GraphALNode.Data + " - " + n.Data;
                    Console.WriteLine(s);
                }
            }
        }
    }



}
