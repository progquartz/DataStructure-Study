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
    class _9252
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static char[] A;
        static char[] B;

        static int[,] dp = new int[1002, 1002];
        /*
         만약 문자열 A가 n글자일때 얻을 수 있는 최대 lcs는 A(n)이며, 이는 n번째가 A(n) + 1임.

         
             */
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.
            A = (' ' + sr.ReadLine()).ToCharArray();
            B = (' ' + sr.ReadLine()).ToCharArray();

            for (int i = 0; i < A.Length; i++)
            {
                dp[i, 0] = 0;
            }
            for (int j = 0; j < B.Length; j++)
            {
                dp[0, j] = 0;
            }

            for (int i = 1; i < A.Length; i++)
            {
                for (int j = 1; j < B.Length; j++)
                {
                    int temp = 0;
                    if (A[i] == B[j])
                    {
                        temp = 1;
                    }
                    dp[i, j] = Math.Max(dp[i - 1, j - 1] + temp, Math.Max(dp[i, j - 1], dp[i - 1, j]));
                }
            }
            Console.WriteLine(dp[A.Length - 1, B.Length - 1]);


            int temp0, temp1, for_j;
            temp1 = dp[A.Length - 1, B.Length - 1];
            temp0 = temp1 - 1;
            for_j = B.Length - 1;
            string LCS = "";

            for (int i = A.Length - 1; i > 0; i--)
            {
                for (int j = for_j; j > 0; j--)
                {
                    if (dp[i, j] == temp1 && dp[i, j - 1] == temp0 && dp[i - 1, j - 1] == temp0 && dp[i - 1, j] == temp0)
                    {
                        temp0--;
                        temp1--;
                        LCS = A[i] + LCS;
                        for_j = j;
                        break;
                    }
                }
            }

            Console.WriteLine(LCS);

        }
    }
}