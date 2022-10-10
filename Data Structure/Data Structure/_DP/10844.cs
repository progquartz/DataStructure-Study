using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{

    class _10844
    {
        public void Solve()
        //static void Main(string[] args)
        {
            List<long[]> dp = new List<long[]>();

            int N = int.Parse(Console.ReadLine());

            long[] firstset = new long[10] { 1,1,1,1,1,1,1,1,1,1 };
            dp.Add(firstset);
            for(int i = 1; i < N; i++)
            {
                long[] tmp = new long[10];
                for(int index = 0; index < 10; index++)
                {
                    long data = 0;
                    if(index > 0)
                    {
                        data += dp[i-1][index - 1] % 1000000000;
                    }
                    if(index < 9)
                    {
                        data += dp[i-1][index + 1] % 1000000000;
                    }
                    data = data % 1000000000;
                    tmp[index] = data;
                }
                dp.Add(tmp);
            }

            long answer = 0;
            for(int j  = 1; j < 10; j++)
            {
                answer += dp[N - 1][j] % 1000000000;
            }
            answer = answer % 1000000000;
            Console.WriteLine(answer);
        }
    }
}
