using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _7562
    {
        static int T;
        static int I;

        static int[] kpos = new int[2];
        static int[] dest = new int[2];

        static int[] dx = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };
        static int[] dy = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };

        static void bfs(int x, int y)
        {
            bool[,] visited = new bool[301, 301];
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[3] {x,y,0});

            while (queue.Count != 0)
            {
                int[] deq = queue.Dequeue();
                if (visited[deq[0], deq[1]] == false)
                {
                    if (dest[0] == deq[0] && dest[1] == deq[1])
                    {
                        Console.WriteLine(deq[2]);
                        break;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        int nx = deq[0] + dx[i];
                        int ny = deq[1] + dy[i];

                        if( 0 <= nx && nx < I && 0 <= ny && ny < I)
                        {
                            queue.Enqueue(new int[3] { nx, ny , deq[2] + 1});
                        }
                    }
                    visited[deq[0], deq[1]] = true;
                }
                
            }
        }

        //static void Main(string[] args)
        public void Solve()
        {
            T = int.Parse( Console.ReadLine());
            
            for(int rotation = 0; rotation < T; rotation++)
            {
                I = int.Parse(Console.ReadLine());
                string[] input = Console.ReadLine().Split();
                kpos[0] = int.Parse(input[0]);
                kpos[1] = int.Parse(input[1]);
                
                input = Console.ReadLine().Split();
                dest[0] = int.Parse(input[0]);
                dest[1] = int.Parse(input[1]);

                bfs(kpos[0], kpos[1]);
            }
        }
    }
}

