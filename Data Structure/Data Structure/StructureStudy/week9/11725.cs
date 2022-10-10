using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _11725
    {
        static StringBuilder sb = new StringBuilder(); // stringbuilder를 통한 Writeline을 사용해야함. 이거 안쓰면 시간초과남. 인생.
        static List<int>[] tree = new List<int>[1];
        static bool[] visited;
        static int[] ans;

        //static void Main(string[] args)
        public void Solve()
        {
            /*
             그래프와 비슷한 형식으로 우선 입력을 받은 다음에, bfs와 비슷한 방법으로 전위 순회를 하는 걸 생각해야할듯.
             bfs로 하면 레벨을 알 수 있지. 그러면 부모를 찾는 거라면 자신과 연결된 애들중에 자기보다 레벨 1 낮은 애가 부모인건 알 수 있는거네.
             */
            int N = int.Parse(Console.ReadLine());

            tree = new List<int>[N + 1];
            for (int i = 0; i < tree.Length; i++)
            {
                tree[i] = new List<int>();
            }
            for (int i = 0; i < N-1; i++)
            {
                string[] input2 = Console.ReadLine().Split();
                int a = int.Parse(input2[0]);
                int b = int.Parse(input2[1]);
                tree[a].Add(b);
                tree[b].Add(a);
            } // 그래프 형식 구현
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            visited = new bool[N + 1];
            ans = new int[N + 1];

            while (queue.Count != 0)
            {
                int deqIndex = queue.Dequeue();
                foreach (int index in tree[deqIndex])
                {
                    if (!visited[index])
                    {
                        visited[index] = true;
                        ans[index] = deqIndex;
                        queue.Enqueue(index);
                    }
                }
            }
            for (int i = 2; i < ans.Length; i++)
            {
                sb.AppendLine(ans[i].ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
