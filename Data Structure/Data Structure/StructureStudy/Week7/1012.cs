using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{

    class _1012
    {
        /*
         이 문제를 풀고 잘 수는 없으니까 텍스트상으로 논리를 정리하고 잘 예정.

        기존에 원래 그래프의 경우에는 간선을 두어 이를 확인하였음. 두가지 풀이 방법이 존재할것 같음.
        1. 붙어 있는 모든 건물 블럭간을 간선으로 만들어 이를 리스트로 저장. 이후에 이를 비교하는것.
        1-1. 이렇게 된다면 문제는 붙지 않은 나머지 부분은 어떻게 해결할지도 확인할 수 있는 방법이 필요함.
        1.2. 예를 든다면 이미 건물로 카운팅된 블럭은 따로 또다른 visited를 만들어 카운팅하지 않는다던가.

        2. 간선은 그 조건이 사방에 다른 리스트가 있는지를 확인하는것이니, 이는 간선으로써 굳이 표현 될 필요가 없는 경우.
        2-1. 근데 이 방법은 머리를 좀 굴려봐야함.

         */

        static StringBuilder sb = new StringBuilder(); // stringbuilder를 통한 Writeline을 사용해야함. 이거 안쓰면 시간초과남. 인생.
        static private bool[,] visited = new bool[70, 70];
        static private int[,] graph = new int[70, 70]; // 리스트의 리스트로 인접 리스트를 구현.
        static int[,] dir = new int[4, 2] { { -1, 0 }, { 1,0 }, { 0, 1 }, { 0, -1 } };
        static int cnt;
        static int n;
        static int m;

        static private void dfs(int x, int y)
        {
            for (int i = 0; i < 4; i++) // 네 방향에 따라 확인 (이는 기존에 노드에 연결되어있는 대상 여부를 확인하는것과 같다.)
            {
                visited[x, y] = true;
                int nx = x + dir[i, 0]; // 상하좌우상태에서의 x좌표.
                int ny = y + dir[i, 1]; // 상하좌우상태에서의 y좌표.

                if (nx >= 0 && ny >= 0 && nx < n && ny < m) // 만약 nx,ny가 좌표 내에 있다면 
                {
                    if ((visited[nx, ny] == false) && (graph[nx, ny] == 1))
                    {
                        cnt++;
                        dfs(nx, ny);
                    }
                }
            }
        }
        //static void Main(string[] args)
        public void Solve()
        {
    
            string[] input1 = Console.ReadLine().Split();
            int loop = int.Parse(input1[0]);
            for(int loopcount = 0; loopcount < loop; loopcount++)
            {
                string[] input2 = Console.ReadLine().Split();
                m = int.Parse(input2[0]);
                n = int.Parse(input2[1]); // 노드의 개수
                int k = int.Parse(input2[2]);

                List<int> result = new List<int>();

                for (int i = 0; i < k; i++)
                {
                    string[] input3 = Console.ReadLine().Split();
                    graph[int.Parse(input3[1]), int.Parse(input3[0])] = 1;
                }


                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (graph[i, j] == 1 && visited[i, j] == false) // 만약 배추가 벌레안묻었으면
                        {
                            visited[i, j] = true;
                            cnt++;
                            dfs(i, j);
                            result.Add(cnt);
                            cnt = 0;
                        }
                    }
                }

                sb.AppendLine(result.Count.ToString());
                //Console.WriteLine(result.Count);

                // 데이터 초기화
                visited = new bool[70, 70];
                graph = new int[70, 70]; 
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
