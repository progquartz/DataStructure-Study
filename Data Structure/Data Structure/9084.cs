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
    class _9084
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int T;
        static int N;
        static int M;
        static int destiny;
        static int moneyLeft;

        static int[] coinData;

        static int[] comb;
        static List<int> combIndex = new List<int>();
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.

            T = int.Parse(Console.ReadLine());

            for(int TestCase = 0; TestCase < T; TestCase++)
            {
                N = int.Parse(Console.ReadLine());

                coinData = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                destiny = int.Parse(Console.ReadLine());
                moneyLeft = destiny;

                comb = new int[10010];
                combIndex = new List<int>();
                // 처음으로 확인해야하는거는 모든 coindata내에서의 최대공약수.
                
                // 만약 어떤 수를 사야한다고 가정했을때, 구매하기 위한 경우의 수를 P[n]이라 하자.
                /* C -> 코인 C? -> 어떤 코인
                 
                0  5 10 15 20 25 30 35 40 45 50 55 60 ... 95 100
                0  1  1  1  1  1  1  1  1  1  2  2  2      2   4

                100... 145 150
                4       4   6


                1원 2원 3원 4원

                1원 5개
                2원 2개 1원 1개
                1원 3개 2원 1개
                3원 1개 1원 2개
                3원 1개 2원 1개
                4원 1개 1원 1개

                0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15
                0 1 2 3 5 6

                P[N]은 P[C] + P[N-C]가 최대인 값이 합쳐지면 됨. 
                배열을 10001개짜리로 만든 다음에
                지금까지 방문한 인덱스를 저장하는 리스트를 만든 다음에, 이에 대한 배열 검색을 하면 될듯?

                */
                for(int i = 0; i < N; i++)
                {
                    comb[coinData[i]] = 1;
                    combIndex.Add(coinData[i]);
                }

                for(int i = 1; i <= destiny; i++)
                {
                    int max = 0;
                    for(int find = 0; find < combIndex.Count; find++)
                    {
                        if (combIndex[find] >= i)
                        {
                            break;
                        }

                        if (comb[combIndex[find]] + comb[i - combIndex[find]] > max)
                        {
                            max = comb[combIndex[find]] + comb[i - combIndex[find]];
                        }
                    }
                    comb[i] = max;
                    combIndex.Add(i);
                }

                Console.WriteLine(comb[destiny]);
            }
        }
    }


}
