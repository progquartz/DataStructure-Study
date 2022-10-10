using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Data_Structure
{
    class _1991
    {
        static StringBuilder sb = new StringBuilder(); // stringbuilder를 통한 Writeline을 사용해야함. 이거 안쓰면 시간초과남. 인생.
        static int[,] tree = new int[28, 2];
        static string answer = "";

        //static void Main(string[] args)
        public void Solve()
        {
            /*
             그래프와 비슷한 형식으로 우선 입력을 받은 다음에, bfs와 비슷한 방법으로 전위 순회를 하는 걸 생각해야할듯.
             bfs로 하면 레벨을 알 수 있지. 그러면 부모를 찾는 거라면 자신과 연결된 애들중에 자기보다 레벨 1 낮은 애가 부모인건 알 수 있는거네.
             */
            int N = int.Parse(Console.ReadLine());

            for(int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();

                int a = char.Parse(input[0]) -64;

                int b = char.Parse(input[1]);
                if (b != 46)
                    tree[a, 0] = b - 64;
                else
                    tree[a, 0] = 0;

                int c = char.Parse(input[2]);
                if (c != 46)
                    tree[a, 1] = c - 64;
                else
                    tree[a, 1] = 0;
            }

            preorder(1);
            Console.WriteLine(answer);
            answer = "";

            midorder(1);
            Console.WriteLine(answer);
            answer = "";

            lastorder(1);
            Console.WriteLine(answer);


        }

        static void levelorder()
        {
                        
            Queue<int> queue = new Queue<int>();
            string answer = "";
            queue.Enqueue(1);

            
            while(queue.Count != 0)
            {
                int deq = queue.Dequeue(); // 1.우선 자신을 리스트에 순위에 넣은 다음에
                answer = answer + (char)(deq + 64);
                // 2. 자신의 좌측을 확인하고
                if(tree[deq,0] != 0)
                {
                    queue.Enqueue(tree[deq, 0]);
                }
                // 3. 자신의 우측도 확인하기.
                if(tree[deq,1] != 0)
                {
                    queue.Enqueue(tree[deq, 1]);
                }
            }
            Console.WriteLine(answer);
            
        }
        static void preorder(int cur)
        {
            answer = answer + (char)(cur + 64);
            if(tree[cur,0] != 0)
            {
                preorder(tree[cur, 0]);
            }
            if(tree[cur,1] != 0)
            {
                preorder(tree[cur, 1]);
            }
        }

        static void midorder(int cur)
        {
            if (tree[cur, 0] != 0)
            {
                midorder(tree[cur, 0]);
            }
            answer = answer + (char)(cur + 64);
            if (tree[cur, 1] != 0)
            {
                midorder(tree[cur, 1]);
            }
        }

        static void lastorder(int cur)
        {
            if (tree[cur, 0] != 0)
            {
                lastorder(tree[cur, 0]);
            }
            
            if (tree[cur, 1] != 0)
            {
                lastorder(tree[cur, 1]);
            }
            answer = answer + (char)(cur + 64);
        }
    }
}
