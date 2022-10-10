using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _2128
    {
        static int r;
        static int ylimit;
        static int xlimit;
        static int cnt = 1;

        static private int[,] step = new int[101, 101];
        static private int[,] graph = new int[101, 101]; // 리스트의 리스트로 인접 리스트를 구현.
        static int[,] dir = new int[4, 2] { { -1, 0 }, { 1, 0 }, { 0, 1 }, { 0, -1 } };

        static private void bfsfor(int x, int y)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[2] { x, y }); // 좌표를 입력받음.
            step[x, y] = cnt; // 이게 몇번째로 방문하는지를 확인하기. 이 부분은 바뀌어야 함.

            while (queue.Count != 0)
            {
                int[] de = queue.Dequeue();
                //Console.WriteLine(de[0] + " , " + de[1]);
                
                for (int i = 0; i < 4; i++) // 네 방향에 따라 확인 (이는 기존에 노드에 연결되어있는 대상 여부를 확인하는것과 같다.)
                {
                    int nx = de[0] + dir[i, 0]; // 상하좌우상태에서의 x좌표.
                    int ny = de[1] + dir[i, 1]; // 상하좌우상태에서의 y좌표.

                    if (nx >= 0 && ny >= 0 && ny < ylimit && nx < xlimit) // 만약 nx,ny가 좌표 내에 있다면 
                    {
                        if((step[nx,ny] == 0 ) && (graph[nx,ny] == 1))
                        {
                            step[nx,ny] = ++cnt;
                            if(step[nx,ny] > step[de[0],de[1]] + 1)
                            {
                                step[nx, ny] = step[de[0], de[1]] + 1;
                            }
                            queue.Enqueue(new int[2] { nx, ny });
                        }
                    }
                }
            }
           
        }


        //static void Main(string[] args)
        public void Solve()
        {
            string[] input2 = Console.ReadLine().Split();
            ylimit = int.Parse(input2[0]); // N 받기 -> y임
            xlimit = int.Parse(input2[1]); // M받기. -> x임.
            

            for (int i = 0; i < ylimit; i++)
            {
                string input3 = Console.ReadLine();
                for(int j = 0; j < xlimit; j++)
                {
                    graph[j, i] = int.Parse(input3[j].ToString());
                }
                
            }

            bfsfor(0, 0);

            /* 상태 확인용
            Console.WriteLine();

            for (int i = 0; i < ylimit; i++)
            {
                for(int j = 0; j < xlimit; j++)
                {
                    Console.Write(step[j,i] + "  ");
                }
                Console.WriteLine();
            }
            */

            Console.WriteLine(step[xlimit - 1, ylimit - 1]);
            

        }
    }
}
