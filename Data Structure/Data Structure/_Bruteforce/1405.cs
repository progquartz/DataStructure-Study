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
    /// 
    /*
    
    로봇이 같은 곳을 한 번보다 많이 이동하지 않을 때, 로봇의 이동 경로가 단순하다고 한다.
    (로봇이 시작하는 위치가 처음 방문한 곳이다.) 로봇의 이동 경로가 단순할 확률을 구하는
    프로그램을 작성하시오. 
    
    예를 들어, EENE와 ENW는 단순하지만, ENWS와 WWWWSNE는 단순하지 않다. 
    (E는 동, W는 서, N은 북, S는 남)

    첫째 줄에 N, 동쪽으로 이동할 확률, 서쪽으로 이동할 확률, 
    남쪽으로 이동할 확률, 북쪽으로 이동할 확률이 주어진다. 
    
    N은 14보다 작거나 같은 자연수이고,  모든 확률은 100보다 작거나 같은 자연수 또는 0이다.
    그리고, 동서남북으로 이동할 확률을 모두 더하면 100이다.

    확률의 단위는 %이다.
    */
    class _1405
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static bool[,] visited = new bool[29, 29];
        static int[] dx = { 0, 0, 1, -1 };
        static int[] dy = { 1, -1, 0, 0 };
        static double[] percent = new double[4];
        static int N;
        static double dfs(int x, int y, int cnt)
        {
            // x,y를 방문했다고 했을때.
            if(cnt == N)
            {
                return 1.0; // 가장 마지막에 도착했는데 못닿았으면 뒤져야지.
            }
            visited[x, y] = true;
            double result = 0.0;

            for(int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if(visited[nx,ny])
                {
                    continue;
                }
                result += percent[i] * dfs(nx, ny, cnt + 1);
                    
            }

            visited[x, y] = false;
            return result;
            
        }
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            // 우선 4가지의 방향 중 한 방향이라도 그 퍼센트가 0이라면, 로봇의 경로는 단순할 수 밖에 없다.
            // 로봇이 제자리로 돌아오기 위한 조건은, V(?,?)에서 n칸 움직인 공간을 V(n,n)이라 할때, 그 경로의 역순 또한 존재해야 하니.
            // 이 문제는 결론적으로 확률을  구하는 문제가 아닌, 경우의 수를 구하고 그 위에 확률을 얹던가, 아니면 경우를 곱하던가 둘 중의 하나일 것이다.

            // 아무래도 브루트 포스를 이용한 백트래킹문제가 될 듯.

            // 1 * 0.25 + 1 * 0.25 + 1 * 0.25 + 1 * 0.25

            // 1* 0.25 *0.25 -> 첫번째 1을 선택할 확률 * 두번째 1을 선택할 확률.

            // dfs 상에서는... stack을 쌓은 채로 두어야하나?

            // 만약 해당 좌표상에 visited를 둔다고 생각하고... 28*28짜리 공간...
            // 4번 움직인다고 가정. 각각 25%

            double[] input = Array.ConvertAll( sr.ReadLine().Split(), double.Parse);
            N = (int)input[0];

            for(int i = 0; i < 4; i++)
            {
                percent[i] = input[i + 1] / 100.0;
            }

            double answer = dfs(14, 14, 0);
            Console.WriteLine(answer);

            sr.Close();
            sw.Close();
        }


    }


}
