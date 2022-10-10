using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            _24479 a = new _24479();
            a.Solve();
        }

    */
        public static void GraphAL()
        {
            GraphAL<int> g = new GraphAL<int>();
            var n1 = g.AddNode(10);
            var n2 = g.AddNode(20);
            var n3 = g.AddNode(30);
            var n4 = g.AddNode(40);
            var n5 = g.AddNode(50);

            g.AddEdge(n1, n3);
            g.AddEdge(n2, n4);
            g.AddEdge(n3, n4);
            g.AddEdge(n3, n5);

            g.DebugPrintLinks();
        }
        public static void GraphAM()
        {
            // 6 implies the number of nodes in graph
            var g = new GraphAM(6);
            //  Add a edge with given nodes
            g.addEdge(0, 1);
            g.addEdge(0, 3);
            g.addEdge(2, 1);
            g.addEdge(2, 3);
            g.addEdge(3, 4);
            g.addEdge(4, 2);
            g.addEdge(4, 5);
            g.addEdge(5, 2);
            // Display node and edge status
            g.adjacencyNode();
        }
    }
}
