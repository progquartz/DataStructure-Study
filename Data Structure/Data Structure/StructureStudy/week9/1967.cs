using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _1967
    {
        static List<Tuple<int, List<int[]>>> tree = new List<Tuple<int, List<int[]>>>();
        static int[] visited = new int[1000000];
        static int[,] max_depth = new int[1000001, 2];

        static int dfs(int visiting)
        {
            Console.WriteLine("방문한" + visiting + "번에 연결된 다른 노드의 수 : " + tree[visiting].Item2.Count);
            // 만약 해당 노드를 방문했다면, 그에 연결된 다른 노드들을 살펴본 다음.
            for (int i = 0; i < tree[visiting].Item2.Count; i++)
            {
                
                int tmp_depth = 0;
                int index = tree[visiting].Item2[i][0]; // 해당 dfs에서 현재 건드리는 인덱스.
                if (visited[index] == 0)
                {
                    visited[index] = 1;
                    Console.WriteLine(index + "로 새로운 dfs를 호출");
                    tmp_depth = dfs(index);
                    if (max_depth[visiting, 1] < tmp_depth + tree[visiting].Item2[i][1])
                    {
                        max_depth[visiting, 1] = tmp_depth + tree[visiting].Item2[i][1];
                        if (max_depth[visiting, 0] < max_depth[visiting, 1])
                        {
                            int tmp = max_depth[visiting, 0];
                            max_depth[visiting, 0] = max_depth[visiting, 1];
                            max_depth[visiting, 1] = tmp;
                        }
                    }
                }
            }

            Console.WriteLine(visiting + " 번째 노드 방문");
            Console.WriteLine("카운트1 : " + max_depth[visiting, 0] + " 카운트 2 : " + max_depth[visiting, 1]);
            return max_depth[visiting, 0];
        }

        //static void Main(string[] args) / 지금 올라온 건 실행 불가능함 노트북에 있으민ㅇ민ㅇㅁㄴ
        public void Solve()
        {
            int N;
            N = int.Parse(Console.ReadLine());

            //tree.Add(new Tuple<int, List<int[]>>(0, new List<int[]>()));
            List<int[]> datas = new List<int[]>();
            int nowcount = 0;
            for(int i = 0; i < N; i++)
            {
                List<int[]> tmplist = new List<int[]>();
                tree.Add(new Tuple<int, List<int[]>>(0, tmplist));
            }
            for (int i = 0; i < N-1; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (int.Parse(input[0]) != nowcount)
                {
                    tree.Add(new Tuple<int, List<int[]>>(nowcount, datas)); // 이전 데이터 flush

                    nowcount = int.Parse(input[0]);
                    Console.WriteLine("nowcount " + nowcount);
                    datas = new List<int[]>();

                }
                int[] data = new int[2] { int.Parse(input[1]), int.Parse(input[2]) };
                datas.Add(data);

            }
            tree.Add(new Tuple<int, List<int[]>>(nowcount, datas)); // 마지막 데이터 flush


            for (int i = 0; i < tree.Count; i++)
            {
                Console.WriteLine(tree[i].Item1 + "에는");
                for (int j = 0; j < tree[i].Item2.Count; j++)
                {
                    Console.Write("(" + tree[i].Item2[j][0] + " , " + tree[i].Item2[j][1] +")");
                }
                Console.WriteLine();
            }

            // 정렬 완료

            visited[1] = 1;
            // dfs 하자.
            dfs(1);
            int tree_length = 0;
            for (int i = 1; i < N + 1; i++)
                if (max_depth[i, 0] + max_depth[i, 1] > tree_length)
                    tree_length = max_depth[i, 0] + max_depth[i, 1];

            Console.WriteLine(tree_length);

        }
    }
}
