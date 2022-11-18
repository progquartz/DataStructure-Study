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
    class _1699
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] dp;
        static int N;
        static int MaxPower = 1;
        static int NextPower = 2;
        public void Solve()
        //static void Main(string[] args)
        {
            // 7 -> 4 - 3
            // 틀린 논리 # 1
            // 어떤 숫자가 있으면 그 숫자의 제곱수의 최소 개수는 7 - 4 = 3-> 3의 최소 개수 + 1
            // 1차원 배열인 O에서 O[n]은 n에서의 제곱수의 최소 개수임. 만약 여기에서 빠질 수 있는 최고로 큰 제곱수를 M[n]이라고 했을때.
            // O[n] = M[n] + (O[n-M[n])임. 
            // 만약 O[n]이 M[n]일 경우에는 O[n]은 1이 됨.
            // O[1]은 1. O[2]는 2임.
            // 가장 큰 제곱수는 한번에 한 단계 이상 높아질 수 없기 때문에, 이를 저장하는 변수를 두고 카운팅 방식으로 계산함.

            // 틀린 논:
            // O[142] = O[81] + O[61];
            // O[n] = O[k-n] + O[k] => // k는 최적이 될 수
            // 여기에서 만약 O[n]이 특정 수의 제곱일 경우, 이를 더해 계산해야만 함.


            /*
             142 = 25 + 36 + 81
             142 ^ 1/2

            142 (25) (36, 81)
                         2 + 1 = O[142]
            /// 

             144 -> 1에서부터 12까지 돌리게 되는 것.

            => 어떤 제곱수 + 제곱수의 집합.으로써 최적화가 될 것이고.

             가장 작은 제곱수(집합 내에서) + 나머지 제곱수들의 집합
                        25                      36 + 81
            O[n] = 나머지 제곱수들의 집합 + 1;
             
             */

            // 1이 필요함.

            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.

            N = int.Parse(sr.ReadLine());

            dp = new int[N + 2];

            for(int i = 0; i < N+2; i++)
            {
                dp[i] = int.MaxValue;
            }

            dp[0] = 0;
            dp[1] = 1;

            for (int number = 1; number <= N; number++)
            {
                int power = 1;

                while (power * power <= number)
                {
                    // O[142] => 142를 만들기 위한 최소의 제곱수 집합수
                    // O[81] => 81를 만들기 위한 최소의 제곱수 => 1이 되는것.
                    // O[61] => 61를 만들기 위한 최소의 제곱수 집합수
                    // 142 =      81 +            61
                    // O[n] = 어떤 제곱수 +   제곱수의 집합.으로써 최적화가 될 것이고.


                    // O[n] =   O[K^2]  +  O[n-(k^2)] 
                    // n = k^2 + n- k^2
                    // 61이라는 수가 있음. 25 + 36
                    if (dp[number] > dp[number - power * power] + 1)
                    {
                        dp[number] = dp[number - power * power] + 1;
                    }

                    power++;
                }
            }

            Console.WriteLine(dp[N]);

            sw.Close();
            sr.Close();
        }
    }


}
