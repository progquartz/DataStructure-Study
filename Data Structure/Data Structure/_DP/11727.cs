using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 실버 3
/// 백트래킹
/// 핵심 -> 점화식이 나올것 같지 않은 문제더라도 점화식은 나온다.
/// </summary>
namespace Data_Structure
{
    class _11727
    {
        public void Solve()
        //static void Main(string[] args)
        {
            // D[i] -> 2*i 크기의 블럭을 채우는 경우의 수.
            // D[i] 에서는 1*2 블럭을 놓거나, 2*1 블럭을 놓거나 2*2블럭을 놓을수 밖에 없음.

            // 따라서, 해당 경우를 볼때, 2*1 블럭을 놓을 경우에는 D[i-1]이 됨.
            // 만약 1*2블럭을 놓게 된다면 이는 D[i-2]가 됨. 2*2도 마찬가지.
            // 그렇기 때문에, D[i] = D[i-1] + 2 * D[i-2]가 된다.

            int N;
            N = int.Parse(Console.ReadLine());

            int[] Darray = new int[N + 1];

            Darray[0] = 1; // 한칸일때.
            Darray[1] = 3; // 두칸일때.
            // 따라서 N칸일때에는 index가 N-1임.
            if (N <= 2)
            {
                Console.WriteLine(Darray[N - 1]);
                return;
            }
            for (int i = 2; i < N; i++)
            {
                Darray[i] = (Darray[i - 1] + 2 * Darray[i - 2]) % 10007;
            }
            Console.WriteLine(Darray[N - 1]);
        }

    }
}
