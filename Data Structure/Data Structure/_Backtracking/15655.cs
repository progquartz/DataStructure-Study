using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _15655
    {
        static int N, M;
        static StringBuilder sb = new StringBuilder();
        static int[] arr; // 데이터가 쌓이는 부분.
        static int[,] used; // 지금까지 데이터가 어떤게 사용되었는지 확인하는 부분.

        // 몇번째가 counting되었는지에 대한 이야기.
        static void Backtracking(int count)
        {
            if (count == M)
            {
                string a = null;
                for (int i = 0; i < M; i++)
                {
                    a += arr[i].ToString() + " ";
                }
                sb.AppendLine(a);
            }
            for (int i = 0; i < N; i++)
            {
                if (used[i, 1] == 0 && (count == 0 || used[i,0] > arr[count - 1]))
                {
                    arr[count] = used[i, 0];
                    used[i, 1] = 1;
                    Backtracking(count + 1);
                    used[i, 1] = 0;
                }
            }
        }

        public void Solve()
        //static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();

            N = int.Parse(input1[0]);
            M = int.Parse(input1[1]);


            used = new int[10, 2]; // n자리.
            string[] input2 = Console.ReadLine().Split();
            for (int i = 0; i < N; i++)
            {
                used[i, 0] = int.Parse(input2[i]);
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N - i; j++)
                {
                    if (j + 1 < N && used[j, 0] > used[j + 1, 0])
                    {
                        used[j, 0] = used[j, 0] + used[j + 1, 0];
                        used[j + 1, 0] = used[j, 0] - used[j + 1, 0];
                        used[j, 0] = used[j, 0] - used[j + 1, 0];
                        used[j, 1] = used[j, 1] + used[j + 1, 1];
                        used[j + 1, 1] = used[j, 1] - used[j + 1, 1];
                        used[j, 1] = used[j, 1] - used[j + 1, 1];
                    }
                }
            }

            arr = new int[10];

            Backtracking(0);
            Console.WriteLine(sb.ToString());
        }
    }
}
