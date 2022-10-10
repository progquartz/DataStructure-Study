using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _7576
    {
        static int M;
        static int N;

        static int[] dirx = new int[4] { -1, 1, 0, 0 };
        static int[] diry = new int[4] { 0, 0, 1, -1 };

        static int[,] data = new int[1001, 1001];
        static Queue<int[]> queue = new Queue<int[]>();
        
        static int bfs()
        {
            int ans = 0;
            while (true)
            {
                Queue<int[]> checkque = new Queue<int[]>();
                while (queue.Count != 0)
                {
                    
                    int[] deq = queue.Dequeue();
                    for (int i = 0; i < 4; i++)
                    {
                        int nx = deq[1] + dirx[i];
                        int ny = deq[0] + diry[i];
                        if (nx >= 0 && ny >= 0 && nx < M && ny < N)
                        {
                            if (data[ny, nx] == 0)
                            {
                                checkque.Enqueue(new int[2] { ny, nx });
                                data[ny, nx] = 1;
                            }
                        }
                    }
                }

                queue = checkque;
                if(queue.Count == 0)
                {
                    return ans;
                }
                ans++;
            }
            
        }

        //static void Main(string[] args)
        public void Solve()
        {
            string[] input = Console.ReadLine().Split();

            M = int.Parse(input[0]); // x
            N = int.Parse(input[1]); // y

            for (int y = 0; y < N; y++)
            {
                string[] input2 = Console.ReadLine().Split();
                for(int x = 0; x < M; x++)
                {
                    data[y,x] = int.Parse(input2[x]);
                    if(int.Parse(input2[x]) == 1)
                    {
                        queue.Enqueue(new int[2] { y, x}); // 3번째는 날짜를 의미.
                        data[y, x] = 1;
                    }
                }
            }
           

            // 전부 다 익었는지 확인.
            bool checkall = true;
            for(int y = 0; y < N; y++)
            {
                for(int x = 0; x < M; x++)
                {
                    if(data[y,x] == 0)
                    {
                        checkall = false;
                        break;
                    }
                }
                if (!checkall)
                {
                    break;
                }
            }
            if (checkall)
            {
                Console.WriteLine(0);
                return;
            }

            int ret = bfs();


            // 만약 다 익지 못하는 상황이면 -1 리턴.
            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < M; x++)
                {
                    if (data[y, x] == 0)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                }
            }

            Console.WriteLine(ret);
            return;


        }
    }
}

