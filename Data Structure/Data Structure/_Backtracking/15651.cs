using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _15651
    {
        static int N, M;
        static StringBuilder sb = new StringBuilder();
        static int[] arr; // 데이터가 쌓이는 부분.

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
                return; // 이번 거에는 used로 인한 최대 n번의 리미트가 사라졌기 떄문에 return을 넣어서 최대 count시 배제.
            }
            for (int i = 1; i <= N; i++)
            {
                arr[count] = i;
                Backtracking(count + 1);
                
            }
        }

        public void Solve()
        //static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();

            N = int.Parse(input1[0]);
            M = int.Parse(input1[1]);

            arr = new int[10];

            Backtracking(0);
            Console.WriteLine(sb.ToString());
        }
    }
}
