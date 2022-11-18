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
    class _1629
    {
        /*
        자연수 A를 B번 곱한 수를 알고 싶다. 
        단 구하려는 수가 매우 커질 수 있으므로 이를 C로 나눈 나머지를 구하는 프로그램을 작성하시오.
             

        첫째 줄에 A, B, C가 빈 칸을 사이에 두고 순서대로 주어진다. A, B, C는 모두 2,147,483,647 이하의 자연수이다.

        */
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static long A ;
        static long B ;
        static long C ;
        static long DivisionConquer1(long R, long N)
        {
            if (N == 1)
            {
                return R;
            }
            else if (N % 2 == 0)
            {
                long half = DivisionConquer1(R, N / 2) % C;
                return half * half;
            }
            else
            {
                return (DivisionConquer1(R, N - 1) % C) * R;
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

            long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            A = input[0];
            B = input[1];
            C = input[2];

            Console.WriteLine(DivisionConquer1(A,B) % C);
        }


    }


}
