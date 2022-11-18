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
    class _12865
    {
        const int WEIGHT = 0;
        const int VALUE = 1;

        /*
        이 문제는 아주 평범한 배낭에 관한 문제이다.

        한 달 후면 국가의 부름을 받게 되는 준서는 여행을 가려고 한다. 
        세상과의 단절을 슬퍼하며 최대한 즐기기 위한 여행이기 때문에, 가지고 다닐 배낭 또한 최대한 가치 있게 싸려고 한다.
        
        준서가 여행에 필요하다고 생각하는 N개의 물건이 있다.
        각 물건은 무게 W와 가치 V를 가지는데, 해당 물건을 배낭에 넣어서 가면 준서가 V만큼 즐길 수 있다. 
        아직 행군을 해본 적이 없는 준서는 최대 K만큼의 무게만을 넣을 수 있는 배낭만 들고 다닐 수 있다. 
        준서가 최대한 즐거운 여행을 하기 위해 배낭에 넣을 수 있는 물건들의 가치의 최댓값을 알려주자.
        
        입력

        첫 줄에 물품의 수 N(1 ≤ N ≤ 100)과 준서가 버틸 수 있는 무게 K(1 ≤ K ≤ 100,000)가 주어진다. 
        두 번째 줄부터 N개의 줄에 거쳐 각 물건의 무게 W(1 ≤ W ≤ 100,000)와 해당 물건의 가치 V(0 ≤ V ≤ 1,000)가 주어진다.
        
        입력으로 주어지는 모든 수는 정수이다. 
             
             */
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int N;
        static int K;

        /*
         

        k번째 보석이 효율적이어서 들어온 경우와, k번째 보석이 효율적이지 못해서 들어오지 못한 경우.

        n(k,w)는 무게 제한이 w이고, k번째 보석의 순서에 최선의 경우이다.

        n(k,w)는 둘 중 하나의 경우임.
        1. k번째 보석이 무거워서 넣지 못한 채로, 이전의 상태를 유지.
        n(k-1, w)
        2. k번째 보석이 넣을 수 있는 상태기 때문에, 넣을 경우와 넣지 않을 경우를 비교.
        max(items[i,VALUE] + n(k,w-items[i,VALUE]) , n(k-1,w)) 
         
        */

        // dp[n,k] = i번째 보석의 최선값.
        static int[,] dp = new int[101, 100001];
        static int[,] items = new int[101, 2];

       
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            N = input[0];
            K = input[1];

            for(int i = 1; i <= N; i++)
            {
                int[] input2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                items[i, WEIGHT] = input2[0];
                items[i, VALUE] = input2[1];
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {

                    if (j - items[i,WEIGHT] >= 0) dp[i,j] = Math.Max(dp[i - 1,j], dp[i - 1,j - items[i,WEIGHT]] + items[i,VALUE]);
                    else dp[i,j] = dp[i - 1,j];
                }
            }

            Console.WriteLine(dp[N, K]);

            sr.Close();
            sw.Close();
        }


    }


}
