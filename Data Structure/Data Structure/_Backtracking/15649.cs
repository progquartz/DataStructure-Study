using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// N M1번
/// 백트래킹
/// 
/// </summary>
namespace Data_Structure
{
    class _15649
    {
        static int N, M;
        static StringBuilder sb = new StringBuilder();
        static int[] arr; // 데이터가 쌓이는 부분.
        static bool[] used; // 지금까지 데이터가 어떤게 사용되었는지 확인하는 부분.

        // 몇번째가 counting되었는지에 대한 이야기.
        static void Backtracking(int count)
        {
            if( count == M)
            {
                string a = null;
                for(int i = 0; i < M; i++)
                {
                    a += arr[i].ToString() + " ";
                }
                sb.AppendLine(a);
            }
            for(int i = 1; i <= N; i++)
            {
                if (!used[i])
                {
                    arr[count] = i;
                    used[i] = true;
                    Backtracking(count + 1);
                    used[i] = false;
                }
            }
        }

        public void Solve()
        //static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();

            N = int.Parse(input1[0]);
            M = int.Parse(input1[1]);

            arr = new int[10];
            used = new bool[10]; // n자리.

            Backtracking(0);
            Console.WriteLine(sb.ToString());
        }
    }
}
