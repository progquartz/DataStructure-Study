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
    /// 입력은 여러 개의 테스트 케이스로 이루어져 있다. 각 테스트 케이스의 첫째 줄에는 지도의 너비 w와 높이 h가 주어진다. 
    /// w와 h는 50보다 작거나 같은 양의 정수이다.
    /// 
    /// 둘째 줄부터 h개 줄에는 지도가 주어진다. 1은 땅, 0은 바다이다.
    /// 입력의 마지막 줄에는 0이 두 개 주어진다.
    /// </summary>
    /// 데이터입력받는 datas array랑    
    /// visited만들어서..
    /// dfs랑 bfs둘다 만들ㅇ버ㅗ면좋을듯.
    class _4963
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[,] datas;
        static bool[,] visited;
        static int w;
        static int h;

        static int[] dx = { -1, -1, 0, 1, 1, 1, 0, -1 };
        static int[] dy = { 0, 1, 1, 1, 0, -1, -1, -1 };
        static void DFS(int x, int y)
        {
            visited[x, y] = true;

            for(int i = 0; i < 8; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                if(nx >= 0 && nx < w && ny >= 0 && ny < h)
                {
                    if(datas[nx,ny] == 1 && visited[nx,ny] == false)
                    {
                        DFS(nx, ny);
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

            while (true)
            {
                int[] input1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                w = input1[0];
                h = input1[1];

                if(w == 0 && h == 0)
                {
                    break;
                }

                datas = new int[w, h];
                visited = new bool[w, h];
                for (int y = 0; y < h; y++)
                {
                    int[] input2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                    for (int x = 0; x < w; x++)
                    {
                        datas[x,y] = input2[x];
                    }
                }

                int cnt = 0;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        if(datas[x,y] == 1 && visited[x,y] == false)
                        {
                            cnt++;
                            DFS(x, y);
                        }
                    }
                }

                /*
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        if(visited[x,y] == true)
                        {
                            sw.Write(1 + " ");
                        }
                        else
                        {
                            sw.Write(0 + " ");
                        }
                        
                    }
                    sw.WriteLine();
                }
                */
                sw.WriteLine(cnt);

            }
            sr.Close();
            sw.Close();
        }


    }


}
