using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{

    class _1260
    {
        static StringBuilder sb = new StringBuilder(); // stringbuilder를 통한 Writeline을 사용해야함. 이거 안쓰면 시간초과남. 인생.
        static private int[] visited = { 0 };
        static List<List<int>> graph = new List<List<int>>(); // 리스트의 리스트로 인접 리스트를 구현.
        static int r;
        static int cnt = 1;

        static private void bfs(int visiting)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(visiting);
            sb.Append(visiting.ToString() + " ");
            visited[visiting] = cnt;

            while (queue.Count != 0)
            {
                int n = queue.Dequeue();
                foreach (int index in graph[n])
                {
                    if (visited[index] == 0) // 방문한 적없다면
                    {
                        sb.Append(index.ToString() + " ");
                        visited[index] = ++cnt;
                        queue.Enqueue(index);
                    }
                }
            }
        }

        static private void dfs(int visiting)
        {
            visited[visiting] = cnt;
            sb.Append(visiting.ToString() + " ");
            foreach (int index in graph[visiting])
            {
                if (visited[index] == 0)
                {
                    cnt++;
                    dfs(index);
                }
            }
        }
        //static void Main(string[] args)
        public void Solve()
        {
            string[] input1 = Console.ReadLine().Split();
            int n = int.Parse(input1[0]); // 노드의 개수
            int m = int.Parse(input1[1]); // 간선의 개수
            r = int.Parse(input1[2]); // 첫 노드

            for (int i = 0; i < n + 1; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < m; i++)
            {
                string[] inputstring = Console.ReadLine().Split();
                graph[int.Parse(inputstring[0])].Add(int.Parse(inputstring[1]));
                graph[int.Parse(inputstring[1])].Add(int.Parse(inputstring[0]));
            }

            for (int i = 0; i < n + 1; i++)
            {
                graph[i].Sort();
            }



            visited = new int[n + 1];
            dfs(r);
            Console.WriteLine(sb.ToString());

            sb.Clear(); // 초기화 작업들...
            visited = new int[n + 1];

            bfs(r);
            Console.WriteLine(sb.ToString());

        }
    }

}
