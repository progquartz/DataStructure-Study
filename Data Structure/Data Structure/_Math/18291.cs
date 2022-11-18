using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    /// <summary>
    /// 현재 만들어놓은 
    /// </summary>
    class _18291
    {
        /*
        비요뜨는 지금 강 앞에 서 있다. 강 위에는 징검다리가 놓여 있다.

        징검다리는 비요뜨가 있는 방향에서부터 반대 방향까지 차례로 1번, 2번, ..., N번의 번호를 가지고 있다.
        
        비요뜨는 1번 징검다리 위에 올라갔다. 그리고 아래 두 가지 규칙을 지키며 징검다리를 건너려고 한다.
        
        1 ≤ X ≤ N 인 임의의 정수 X에 대해, 현재 있는 징검다리의 번호를 i번이라고 할 때 i+X번 징검다리로 뛸 수 있다.
        N번째 징검다리를 지나쳐선 안 되고, 정확히 도착해야 한다
        비요뜨는 자신의 특기인 코딩을 살리기 위해 노트북을 켰지만, 실수로 노트북을 강에 빠뜨리고 말았다.
        
        비요뜨를 대신해 강을 건너는 경우의 수를 구해 주자! 

        1번과 N번을 제외하고는 나머지는 전부 켜고 키는 스위치. 결론적으로, 이 문제는 2^(N-2)를 구하는 문제임.
        이를 분할제곱을 이용한 거듭제곱으로 풀으라는 것.
             
        */
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static long DivisionConquer1(int N)
        {
            if(N == 1)
            {
                return 2;
            }
            else
            {
                long x = DivisionConquer1(N / 2);
                if (N % 2 == 0)
                {
                    return (x * x) % 1000000007;
                }
                else
                {
                    return (x * x * 2) % 1000000007;
                }
            }
        }

        static long DivisionConquer2(long a, long b)
        {
            long res = 1;

            while (b > 0)
            {
                if ((b & 1) == 1)
                    res *= a;

                a = a * a;
                b >>= 1;
            }

            return res;
        }

        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int TestCase = int.Parse(Console.ReadLine());

            for(int T = 0; T < TestCase; T++)
            {
                int N = int.Parse(Console.ReadLine());
                if(N == 1 || N == 2)
                {
                    Console.WriteLine(1);
                    continue;
                }
                Console.WriteLine( DivisionConquer1(N-2));
            }
        }


    }


}
