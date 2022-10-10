using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _16928
    {
        static int N;
        static int M;

        static bool[] visited = new bool[106];
        static int[] teleport = new int[106];
        static Queue<int[]> queue = new Queue<int[]>();
        static private void bfs()
        {
            while(queue.Count != 0)
            {
                int[] deq = queue.Dequeue();
                if(visited[deq[0]] == false)
                {
                    if (deq[0] == 100) // 등반완료
                    {
                        Console.WriteLine(deq[1]); // bfs이기 때문에 가장 먼저 도착하면 그게 가장 낮은 count임.
                        break;
                    }

                    for (int dice = 1; dice <= 6; dice++)
                    {
                        if (teleport[deq[0] + dice] == 0) // 해당 위치에 텔포가 없으면.
                        {
                            int nx = deq[0] + dice;
                            if (nx <= 100)
                            {
                                queue.Enqueue(new int[2] { nx, deq[1] + 1 });
                            }
                            visited[deq[0]] = true;
                        }
                        else
                        {
                            int nx = teleport[deq[0] + dice];
                            if (nx <= 100)
                            {
                                queue.Enqueue(new int[2] { nx, deq[1] + 1 });
                            }
                        }
                    }
                }
                //Console.WriteLine(deq[1]);
            }
        }


        //static void Main(string[] args)
        public void Solve()
        {
            string[] input1 = Console.ReadLine().Split();
            N = int.Parse(input1[0]);
            M = int.Parse(input1[1]);
            for(int i = 0; i < N; i++)
            {
                string[] input2 = Console.ReadLine().Split();
                teleport[int.Parse(input2[0])] = int.Parse(input2[1]);
            }
            for(int i = 0; i < M; i++)
            {
                string[] input2 = Console.ReadLine().Split();
                teleport[int.Parse(input2[0])] = int.Parse(input2[1]);
            }

            queue.Enqueue(new int[2] { 1, 0 });

            bfs();
        }
    }
}
