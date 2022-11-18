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
    /// 
    /// 어느 순간이동 기기는, 이전 작동시기에 k광년을 이동하였을 때는 k-1 , k 혹은 k+1 광년만을 다시 이동할 수 있다.
    /// 이 장치를 처음 작동시킬 경우 -1 , 0 , 1 광년을 이론상 이동할 수 있으나 사실상 음수 혹은 0 거리만큼의 이동은 의미가 없으므로 1 광년을 이동할 수 있으며, 
    /// 그 다음에는 0 , 1 , 2 광년을 이동할 수 있는 것이다. (여기서 다시 2광년을 이동한다면 다음 시기엔 1, 2, 3 광년을 이동할 수 있다. )
    /// 
    /// 김우현은 공간이동 장치 작동시의 에너지 소모가 크다는 점을 잘 알고 있기 때문에 x지점에서 y지점을 향해 최소한의 작동 횟수로 이동하려 한다.
    /// 하지만 y지점에 도착해서도 공간 이동장치의 안전성을 위하여 y지점에 도착하기 바로 직전의 이동거리는 반드시 1광년으로 하려 한다.
    /// 김우현을 위해 x지점부터 정확히 y지점으로 이동하는데 필요한 공간 이동 장치 작동 횟수의 최솟값을 구하는 프로그램을 작성하라.
    /// </summary>
    class _1011
    {
        /*
        데이터에서 저장할 것 -> 현재 데이터값에서 1까지 가는데에 걸리는 시간.
        최적의 경우는 다음과 같음.
        1 + 2 + ... n + n + n + ... 2 + 1.
        결론적으로 무조건적으로 포함되어야 하는 것은 1에서부터 n까지의 합의 2배와

        1+2+3+n-1+n+n-1... 1
        n-1 * n / 2 // 1에서부터 n-1까지의 합.
        n * n+1 / 2 // 1에서부터 n까지의 합.

        이 이후부터는 그리디로 쫘라락 빼면 끝~;
        1 2 3 4 5 4 3 2 1 
            (n-1 * n) + (n * n+1) / 2 = 2n * n / 2 = n^2
             
        */
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int testCase = int.Parse(sr.ReadLine());

            for(int t = 0; t < testCase; t++)
            {
                int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int x = input[0];
                int y = input[1];

                // 이동은 1에서 n까지, 그리고 n-1에서 1까지 다시한번 이루어져야만 한다.

                int diff = y - x;
                //Console.WriteLine(diff);
                int sqr = (int)Math.Sqrt(diff); // 이게 n임.
                //Console.WriteLine(sqr);
                // n구하기.
                int leftoff = diff - (sqr * sqr); // 최종점까지 전부 한 수.
                
                //Console.WriteLine(leftoff);
                int normalcount = 2 * sqr - 1;// 1에서 n까지, n-1에서 1까지. 
                //Console.WriteLine(normalcount);


                int leftcount;

                if (leftoff % sqr == 0)
                {
                    // 완벽히 나누ㅜ어진다면 추가적으로 더 더할 필요 없음.
                    leftcount = leftoff / sqr;
                }
                else
                {
                    leftcount = leftoff / sqr + 1;
                }

                Console.WriteLine(normalcount + leftcount);
                


            }
            sr.Close();
            sw.Close();
        }


    }


}
