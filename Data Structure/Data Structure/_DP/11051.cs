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
    class _11051
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static long[,] datas = new long[1001, 1001];

        static long GetCoefficient(long n, long r)
        {
        /*
        nCr = n-1Cr + n-1Cr-1
        
        nCr = n! / (r!(n-r))!
        
        1C1 = 0C1 + 0C0
        
        2C1 = 1C1 + 1C0
        
        2C1 = 1C1 + 1C0
        
        3c1 = 2c1 + 2c0
        
        고로 초기화가 필요한 것은 1c0, 0c1일듯.
        
        이 경우에는 n과 R의 크기의 배열로 이를 저장 가능하다.
        
        0c0 = 1;
        oc1 = 0;
        1c0 = 1;
        
        nc0 = 1;
        ncn = 1;
        */
            if(r > n)
            {
                return 0;
            }

            if(datas[n,r] > 0)
            {
                return datas[n, r];
            }
            if(r == 0 || n == r)
            {
                return datas[n,r] = 1;
            }
            
            return datas[n,r] = (GetCoefficient(n - 1, r) + GetCoefficient(n - 1, r - 1)) % 10007;
            

        }
        public void Solve()
        //static void Main(string[] args)
        {

            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            long[] input = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            long N = input[0];
            long K = input[1];

            Console.WriteLine(GetCoefficient(N, K));
            
            sr.Close();
            sw.Close();
        }


    }


}
