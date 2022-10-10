using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 실버 2
/// 백트래킹
/// 핵심 -> 머리에서 배열끼리의 연산을 좀더 잘 굴려보자.
/// </summary>
namespace Data_Structure
{
    class _1912
    {
        public void Solve()
        //static void Main(string[] args)
        {
            // 만약 지금까지의 최대치에 자신을 더한 값보다, 자신이 더 크면 자신이 더 큰 것이고, 아니면 최대치에 자신을 더한 값이 최대값이다.
            // 자신이 더 큰 경우에는 연결이 끊기는 것.
            // 최대치가 d[i], 배열이 a[i]라고 한다면 d[i] = max(d[i-1] + a[i], a[i])이다.

            int N = int.Parse(Console.ReadLine());

            int[] data = new int[N + 1];

            string[] input = Console.ReadLine().Split();
            data[0] = int.Parse(input[0]);

            for(int i = 1; i < N; i++)
            {
                int a = int.Parse(input[i]);
                data[i] = Math.Max(data[i - 1] + a, a);
            }

            int max = int.MinValue;
            for(int i = 0; i < N; i++)
            {
                if(data[i] > max)
                {
                    max = data[i];
                }
            }
            Console.WriteLine(max);
        }
    }
}
