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
    class _2293
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int N;
        static int K;

        static int[] coins;
        static int[] datas = new int[100001];
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            int[] input1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            N = input1[0];
            K = input1[1];

            coins = new int[N];
            for(int i = 0; i < N; i++)
            {
                coins[i] = int.Parse(sr.ReadLine());
            }

            // 어떤 수를 얻기 위한 최소조건은 
            // n[k]가 있다면 존재하는 모든 코인인 C에서
            // n[k] - C가 가 0이상이라면
            // n[k] - C의 값이 존재한다면 + n[K-C]
            // n[k] - C의 값이 존재하지 않는다면 플러스하지 않음!.

            // n[k] - C가 0 아래라면
            // 뭐 없음.
            // 한 것 아닌가?

            datas[0] = 1;

            for (int i = 0; i < N; i++)
            { //각 동전에 대해
                for (int j = coins[i]; j <= K; j++)
                {
                    datas[j] += datas[j - coins[i]];
                }
            }

            
            Console.Write(datas[K]);
            



            sr.Close();
            sw.Close();
        }


    }


}
