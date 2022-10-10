using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    public class GraphAM
    {
        // Graph node
        public int[,] node;
        // Number of nodes
        public int size;
        public GraphAM(int size)
        {
            if (size <= 0)
            {
                // Invalid number of nodes
                return;
            }
            this.node = new int[size, size];
            this.size = size;
        }
        public void addEdge(int start, int end)
        {
            if (this.size > start && this.size > end)
            {
                // Set the connection
                this.node[start, end] = 1;
            }
        }
        public void adjacencyNode()
        {
            if (this.size > 0)
            {
                for (var row = 0; row < this.size; row++)
                {
                    Console.Write("인접 행렬 간선 " + row.ToString() + " :");
                    for (var col = 0; col < this.size; col++)
                    {
                        if (this.node[row, col] == 1)
                        {
                            Console.Write(" " + col.ToString());
                        }
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                Console.WriteLine("Empty Graph");
            }
        }
    }
}
