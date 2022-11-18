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
    class _11444
    {
        
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // Fn+2 = Fn+1 + Fn
        // Fn+1 = Fn+1



        /*
        피보나치 수열은 그 점화식이
        F(n) = F(n-1) + F(n-2)이다.

            F(N) = [F(n+2) F(n+1)] 
                   [F(n+1) F(n)  ]
            F(1) = [1      1     ]
                   [1      0     ]
            
        */

        // 행렬곱함수.
        static long[,] mult(long[,] a, long[,] b)
        {
            long[,] temp = new long[2,2];


            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        temp[i,j] += (a[i,k] * b[k,j]) % 1000000007;
                    }
                    temp[i,j] %= 1000000007;
                }
            }

            return temp;
        }


        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            long n = long.Parse(Console.ReadLine());
            
            long[,] ans = new long[2, 2] { {1,0 }, {0,1 } };
            long[,] a = new long[2, 2] { { 1, 1 }, { 1, 0 } };

            while(n > 0)
            {
                if(n % 2 == 1)
                {
                    ans = mult(ans,a);
                }
                a = mult(a, a);
                n /= 2;
            }

            Console.WriteLine(ans[0,1]);

        }


    }


}
