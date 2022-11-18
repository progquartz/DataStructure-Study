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
    /// 
    /*
    1 2 3 4 5 6 7 8 9
      1       5
    만약 케이스에서 두 원소를 선택했을 경우 
    그 두 원소가 가장 높은 수치와 낮은 수치가 되는 경우의 수는
    ( (n - 2)c0 + (n - 2)c1 + .... + (n - 2)c(선택한 두 원소의 인덱스 차-1) )이다.
    
    
    2와 6사이에서 그 수를 선택할 경우 경우의 수는
    1(2,6) + 3c1 + 3c2 + 3c3임. = 2^(6의 인덱스 - 2의 인덱스 - 1)
    
     https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=vollollov&logNo=220947452823
    이제 구해야 할 것은...
    
    모든 경우에서 2가지를 선택하는 경우를 고르면 됨.

 
         */

    /*
     x보다 작은 수가 i개 있다면 x가 최대가 되는 조합의 수는 2^i임
     x보다 큰 수가 j개 있다면 x가 최소가 되는 조합의 수는 2^j임.

    모든 x에 대해 x보다 작은 수가 i개, x보다 큰 수가 j개 있다면 (2i - 2j) * x가 그 해답임.

     */
    class _15824
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int N;
        static long[] datas;
        static long[] binary = new long[300001];

        static long DivisionConquer1(int N)
        {
            if(binary[N] > 0)
            {
                return binary[N];
            }
            if(N == 0)
            {
                binary[N] = 1;
                return binary[N];
            }
            if (N == 1)
            {
                binary[N] = 2;
                return binary[N];
            }
            else
            {
                long x = DivisionConquer1(N / 2);
                if (N % 2 == 0)
                {
                    binary[N] = (x * x) % 1000000007;
                    return binary[N];
                }
                else
                {
                    binary[N] = (x * x * 2) % 1000000007;
                    return binary[N];
                }
            }
        }

        static void PutBinary(int N)
        {
            for (int i = 0; i < N+1; i++)
            {
                binary[i] = DivisionConquer1(i);
            }
        }
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            N = int.Parse(sr.ReadLine());
            int MOD = 1000000007;
            datas = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            Array.Sort(datas);

            PutBinary(N);

            /*
            for(int i = 0; i < N+1; i++)
            {
                Console.WriteLine(binary[i]);
            }
            */

            long sum = 0;

            for (int i = 0; i < N; ++i)
            {
                long max_cnt = DivisionConquer1(i);
                long min_cnt = DivisionConquer1(N - i - 1);

                sum = (sum + (((max_cnt - min_cnt) % MOD) * (datas[i] % MOD)) % MOD + MOD) % MOD;
            }

            sw.WriteLine(sum);
            sr.Close();
            sw.Close();
        }


    }


}
