using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _1167
    {
        static List<Tuple<int, int[,]>> tree = new List<Tuple<int, int[,]>>();
        static int[] visited = new int[1000000];
        static int[,] max_depth = new int[1000001, 2];
        static int totalmax = 0;
        static int dfs(int visiting)
        {
            
            // 만약 해당 노드를 방문했다면, 그에 연결된 다른 노드들을 살펴본 다음.
            for (int i = 0; i < tree[visiting].Item2.Length / 2; i++)
            {
                
                int tmp_depth = 0;
                int index = tree[visiting].Item2[i, 0]; // 해당 dfs에서 현재 건드리는 인덱스.
                if (visited[index] == 0)
                {
                    visited[index] = 1;
                    tmp_depth = dfs(index);
                    if (max_depth[visiting, 1] < tmp_depth + tree[visiting].Item2[i, 1] )
                    {
                        max_depth[visiting, 1] = tmp_depth + tree[visiting].Item2[i, 1];
                        if(max_depth[visiting, 0] < max_depth[visiting, 1])
                        {
                            int tmp = max_depth[visiting, 0];
                            max_depth[visiting, 0] = max_depth[visiting, 1];
                            max_depth[visiting, 1] = tmp;
                        }
                    }
                }
            }
            
            //Console.WriteLine(visiting + " 번째 노드 방문");
            //Console.WriteLine("카운트1 : " + max_depth[visiting, 0] + " 카운트 2 : " + max_depth[visiting, 1]);
            return max_depth[visiting,0];
        }

        //static void Main(string[] args)
        public void Solve()
        {
            int V;
            int rootConnected = 0;
            V = int.Parse(Console.ReadLine());

            
            /*
            if (V <= 3)
            {
                Console.WriteLine(V);
                return; // 예외처리.
            }
            */
            

            tree.Add(new Tuple<int, int[,]>(0, new int[1, 1] { { 0 } }));

            for(int i = 0; i < V; i++)
            {
                string[] input = Console.ReadLine().Split();
                int[,] datas = new int[(input.Length /2)- 1, 2];

                for(int j = 0; j < (input.Length / 2) - 1; j++)
                {
                    datas[j, 0] = int.Parse(input[2 * j + 1]);
                    datas[j, 1] = int.Parse(input[2 * j + 2]);
                }
                tree.Add(new Tuple<int, int[,]>(int.Parse(input[0]), datas));
            }

            tree.Sort(); // 이거 문제있다 니미
            
            for(int i = 1; i < V+1; i++)
            {
                //Console.WriteLine(tree[i].Item1 + "에는");
                for(int j = 0; j < tree[i].Item2.Length / 2; j++)
                {
                    //Console.Write("(" + tree[i].Item2[j,0] + " , " + tree[i].Item2[j, 1] +")");
                }
                //Console.WriteLine();
            }

            // 정렬 완료

            visited[1] = 1;
            // dfs 하자.
            dfs(1);
            int tree_length = 0;
            for (int i = 1; i < V+1; i++)
                if (max_depth[i,0] + max_depth[i,1] > tree_length)
                    tree_length = max_depth[i,0] + max_depth[i,1];

            Console.WriteLine(tree_length);
            




        }


    }
}
