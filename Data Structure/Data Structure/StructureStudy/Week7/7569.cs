using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _7569
    {
        static int M;
        static int N;
        static int H;

        static int[] dirx = new int[6] { 1, -1, 0, 0, 0, 0 };
        static int[] diry = new int[6] { 0, 0, 1, -1, 0, 0 };
        static int[] dirz = new int[6] { 0, 0, 0, 0, 1, -1 };

        static int[,,] data = new int[101, 101, 101];
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
                    for (int i = 0; i < 6; i++)
                    {
                        int nz = deq[2] + dirz[i];
                        int nx = deq[1] + dirx[i];
                        int ny = deq[0] + diry[i];
                        if (nx >= 0 && ny >= 0 && nz >= 0 && nx < M && ny < N && nz < H)
                        {
                            if (data[ny, nx, nz] == 0)
                            {
                                checkque.Enqueue(new int[3] { ny, nx , nz});
                                data[ny, nx, nz] = 1;
                            }
                        }
                    }
                }

                queue = checkque;
                if (queue.Count == 0)
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
            H = int.Parse(input[2]); // z

            for(int z = 0; z < H; z++)
            {
                for (int y = 0; y < N; y++)
                {
                    string[] input2 = Console.ReadLine().Split();
                    for (int x = 0; x < M; x++)
                    {
                        data[y, x ,z]= int.Parse(input2[x]);
                        if (int.Parse(input2[x]) == 1)
                        {
                            queue.Enqueue(new int[3] { y, x ,z}); // 3번째는 날짜를 의미.
                            data[y, x ,z] = 1;
                        }
                    }
                }
            }
            


            // 전부 다 익었는지 확인.
            bool checkall = true;
            for(int z = 0; z < H; z++)
            {
                for (int y = 0; y < N; y++)
                {
                    for (int x = 0; x < M; x++)
                    {
                        if (data[y, x, z] == 0)
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

            }
            if (checkall)
            {
                Console.WriteLine(0);
                return;
            }

            int ret = bfs();

            // 만약 다 익지 못하는 상황이면 -1 리턴.
            for (int z = 0; z < H; z++)
            {
                for (int y = 0; y < N; y++)
                {
                    for (int x = 0; x < M; x++)
                    {
                        if (data[y, x,z] == 0)
                        {
                            Console.WriteLine(-1);
                            return;
                        }
                    }
                }
            }
                
            Console.WriteLine(ret);
            return;


        }
    }
}

