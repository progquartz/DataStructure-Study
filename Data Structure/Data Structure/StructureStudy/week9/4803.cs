using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _4803
    {
        static List<List<int>> graph = new List<List<int>>();

        //static void Main(string[] args)
        public void Solve()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input == null)
                {
                    break;
                }
                int N = int.Parse(input[0]);
                int M = int.Parse(input[1]);

                for(int i = 0; i < N; i++)
                {
                    graph.Add(new List<int>());   
                }
                for(int i = 0; i < M; i++)
                {
                    string[] input2 = Console.ReadLine().Split();
                    //int a = 
                }
            }
        }
        
    }
}
