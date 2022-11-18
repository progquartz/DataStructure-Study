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
    class _10026
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static char[,] datas;
        static bool[,] visited;
        static int N;
        static int[] dx = { 0, 0, 1, -1 };
        static int[] dy = { 1, -1, 0, 0 };
        static void DFSNone(int x, int y, char type)
        {
            visited[x, y] = true;
            for(int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                {
                    if(visited[nx,ny] == false)
                    {
                        if (datas[nx, ny] == type)
                        {
                            DFSNone(nx, ny, type);
                        }

                    }
                }
            }
           
        }

        static void DFSError(int x, int y, char type)
        {
            visited[x, y] = true;
            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                {
                    if(visited[nx,ny] == false)
                    {
                        if (datas[nx, ny] != 'B' && type != 'B')
                        {
                            DFSError(nx, ny, type);
                        }
                        else if (datas[nx, ny] == 'B' && type == 'B')
                        {
                            DFSError(nx, ny, type);
                        }
                    }
                   
                }
            }
        }
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            N = int.Parse(sr.ReadLine());

            datas = new char[N, N];

            for(int j = 0; j < N; j++)
            {
                string input = sr.ReadLine();
                for(int i = 0; i < N; i++)
                {
                    datas[i, j] = input[i];
                }
            }


            visited = new bool[N, N];
            int cnt = 0;
            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < N; i++)
                {
                     if(visited[i,j] == false)
                    {
                        cnt++;
                        DFSNone(i, j, datas[i, j]);
                    }
                }
            }
            sw.Write(cnt + " ");

            visited = new bool[N, N];
            cnt = 0;
            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if (visited[i, j] == false)
                    {
                        cnt++;
                        DFSError(i, j, datas[i, j]);
                    }
                }
            }
            sw.Write(cnt);





            sr.Close();
            sw.Close();
        }


    }


}

