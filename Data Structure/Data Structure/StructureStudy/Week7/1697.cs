using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _1697
    {
        static int r;
        static int n;
        static int k;
        static int cnt = 1;
        static bool[] step = new bool[100001];

        static int min = int.MaxValue;
        
        static void bfs(int n, int k)
        {

            Queue<int []> queue = new Queue<int[]>();


            queue.Enqueue(new int[2] {n,0});
        
            while(queue.Count != 0)
            {
                int []deq = queue.Dequeue();
                
                if(!step[deq[0]])// 굳이 더 높은 깊이에서 얕은 깊이에 만들어두었던 친구를 찾을 필요는 없다.
                {
                    if(deq[0] == k) // 다음의 경우에서 깊이가 낮으면 낮을수록 최적(cnt)이 되기 떄문. 
                    {
                        Console.WriteLine(deq[1]);
                    }

                    // -1을 한 경우
                    if(deq[0] - 1 >= 0)
                    {
                        queue.Enqueue(new int[2] { deq[0] - 1, deq[1] + 1 });
                    }
                    // +1을 한 경우
                    if(deq[0] + 1 <= 100000)
                    {
                        queue.Enqueue(new int[2] { deq[0] + 1, deq[1] + 1 });
                    }
                    // 텔레포트를 하는 경우.
                    if (deq[0] * 2 <= 100000)
                    {
                        queue.Enqueue(new int[2] { deq[0] * 2, deq[1] + 1 });
                    }
                    step[deq[0]] = true;
                }
            }
        }


        //static void Main(string[] args)
        public void Solve()
        {
            string[] input2 = Console.ReadLine().Split();
            n = int.Parse(input2[0]); // N 받기 -> y임
            k = int.Parse(input2[1]); // M받기. -> x임.

            bfs(n, k);

        }
    }
}
