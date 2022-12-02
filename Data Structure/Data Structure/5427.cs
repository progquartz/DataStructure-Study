using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    /// <summary>
    /// 현재 만들어놓은 
    /// </summary>
    class _5427
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int w;
        static int h;
        static char[,] data = null;
        static int[,] fireVisited = null ;
        static int[,] playerVisited = null;

        static List<int[]> fireList;
        static int[] playerPos;

        static int[] dx = new int[4] { 0, 0, 1, -1 };
        static int[] dy = new int[4] { 1, -1, 0, 0 };
        
        static void FireBFS()
        {
            Queue<int[]> queue = new Queue<int[]>();
            for(int i = 0; i < fireList.Count; i++)
            {
                int[] firelist = new int[3] { fireList[i][0], fireList[i][1], 1 };
                queue.Enqueue(firelist);
            }

            while(queue.Count != 0)
            {
                int[] deq = queue.Dequeue();
                fireVisited[deq[0], deq[1]] = deq[2];

                for(int i = 0; i < 4; i++)
                {
                    int nx = deq[0] + dx[i];
                    int ny = deq[1] + dy[i];

                    if(nx >= 0 && ny >= 0 && nx < w && ny < h)
                    {
                        // 범위 내에 있고, 조건이 맞는다면...
                        if(fireVisited[nx,ny] == int.MaxValue && data[nx,ny] != '#')
                        {
                            int[] pos = new int[3] { nx, ny, deq[2] + 1 };
                            queue.Enqueue(pos);
                        }
                    }
                }
                
            }

        }

        static void PlayerBFS(int x, int y)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[3] { x, y ,1});
            while (queue.Count != 0)
            {
                int[] deq = queue.Dequeue();
                playerVisited[deq[0], deq[1]] = deq[2];

                if (deq[0] == 0 || deq[1] == 0 || deq[0] == w - 1 || deq[1] == h - 1)
                {
                    sw.WriteLine(deq[2]);
                    return;
                }

                for (int i = 0; i < 4; i++)
                {
                    int nx = deq[0] + dx[i];
                    int ny = deq[1] + dy[i];

                    if (nx >= 0 && ny >= 0 && nx < w && ny < h)
                    {
                        // 범위 내에 있고, 조건이 맞는다면...
                        if (playerVisited[nx, ny] < 0 && data[nx, ny] != '#' && fireVisited[nx,ny] > deq[2] + 1)
                        {
                            if(nx == 0 || ny == 0 || nx == w-1 || ny == h - 1)
                            {
                                sw.WriteLine(deq[2] + 1);
                                return;
                            }
                            int[] pos = new int[3] { nx, ny, deq[2] + 1 };
                            queue.Enqueue(pos);
                        }
                    }
                }
            }
            sw.WriteLine("IMPOSSIBLE");
        }
        
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int N;

            N = int.Parse(sr.ReadLine());

            for (int n = 0; n < N; n++)
            {
                int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                w = input[0];
                h = input[1];

                data = new char[w, h];
                fireVisited = new int[w, h];
                playerVisited = new int[w, h];
                fireList = new List<int[]>();
                for (int y = 0; y < h; y++)
                {
                    string input2 = sr.ReadLine();
                    for (int x = 0; x < w; x++)
                    {
                        if (input2[x] == '@')
                        {
                            playerPos = new int[2] { x, y };
                        }
                        if (input2[x] == '*')
                        {
                            int[] fire = new int[2] { x, y };
                            fireList.Add(fire);
                        }
                        data[x, y] = input2[x];
                    }
                }
                for (int y = 0; y < h; y++)
                {

                    for (int x = 0; x < w; x++)
                    {
                        fireVisited[x, y] = int.MaxValue;
                        playerVisited[x, y] = -1;
                    }
                }

                FireBFS();
                
                /*
                for (int y = 0; y < h; y++)
                {
                    
                    for (int x = 0; x < w; x++)
                    {
                        Console.Write(fireVisited[x, y]);
                    }
                    Console.WriteLine();
                }
                */
                

                PlayerBFS(playerPos[0], playerPos[1]);






                sr.Close();
                sw.Close();
            }

        }


    }


}
