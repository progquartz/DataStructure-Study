using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    /*
     N개의 정점과 M개의 간선으로 구성된 무방향 그래프(undirected graph)가 주어진다.
     정점 번호는 1번부터 N번이고 모든 간선의 가중치는 1이다. 

     정점 R에서 시작하여 깊이 우선 탐색으로 노드를 방문할 경우 노드의 방문 순서를 출력하자.

    
    dfs(V, E, R) {  # V : 정점 집합, E : 간선 집합, R : 시작 정점
    visited[R] <- YES;  # 시작 정점 R을 방문 했다고 표시한다.
    for each x ∈ E(R)  # E(R) : 정점 R의 인접 정점 집합.(정점 번호를 오름차순으로 방문한다)
    if (visited[x] = NO) then dfs(V, E, x);
}
         */
    class _24479
    {
        static private int[] visited = { 0 };
        static List<List<int>> graph = new List<List<int>>(); // 리스트의 리스트로 인접 리스트를 구현.
        static int r;
        static int cnt = 1;

        static private void dfs(int visiting)
        {
            visited[visiting] = cnt;
            foreach(int index in graph[visiting])
            {
                if(visited[index] == 0)
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

            for(int i = 0; i < n+1; i++)
            {
                graph.Add(new List<int>());
            }

            for(int i = 0; i < m; i++)
            {
                string[] inputstring = Console.ReadLine().Split();
                graph[int.Parse(inputstring[0])].Add(int.Parse(inputstring[1]));
                graph[int.Parse(inputstring[1])].Add(int.Parse(inputstring[0]));
            }

            for(int i = 0; i < n+1; i++)
            {
                graph[i].Sort();
            }



            visited = new int[n + 1];
            dfs(r);


            StringBuilder sb = new StringBuilder(); // stringbuilder를 통한 Writeline을 사용해야함. 이거 안쓰면 시간초과남. 인생.

            for (int i = 0; i < visited.Length; i++)
            {
                if(i != 0)
                {
                    sb.AppendLine(visited[i].ToString());
                    //Console.WriteLine(visited[i]);
                }
            }
            Console.Write(sb.ToString());
        }
    }

}
