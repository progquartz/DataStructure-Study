using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _2579
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] p;
        static int[] d;
        static int N;
        static void BackTracking()
        {
            d[0] = 0;
            d[1] = p[1];
            d[2] = p[1] + p[2];
            for(int i = 3; i <= N; i++)
            {
                d[i] = p[i] + Math.Max(d[i - 3] + p[i - 1], d[i - 2]);
            }
            
        }

        public void Solve()
        //static void Main(string[] args)
        {
            /*
             우선 구하고자 하는 층의 최댓값을 d[i]이라 하고 각 층의 값은 p[i]이라고 하자.
            d[i] = p[i] + max(d[i-1], d[i-2])


            그러나 문제의 조건 중에서는 연속된 세 개의 계단은 밟을 수 없다는 조건이 있으므로 이를 고려해야 한다.
            만약 그 전의 블럭을 밟지 않아 i-2칸을 밟는 경우는 별 상관이 없음.
            하지만, 전 칸을( p[i-1])을  밟았다고 가정한다면, 이 경우에는 p[i-2]를 밟을 수는 없음. 따라서 p[i-3]번째 칸을 더해야지만 3칸 연속이 아니게 됨.
            
            d[i] = p[i] + max(d[i-3] + p[i-1], d[i-2])
             */
            StreamReader sr = new StreamReader(new System.IO.BufferedStream(Console.OpenStandardInput()));

            N = int.Parse(Console.ReadLine());

            d = new int[301];
            p = new int[301];
            for (int i = 1; i <= N; i++)
            {
                p[i] = int.Parse(Console.ReadLine());
            }


            BackTracking();
            Console.WriteLine(d[N]);
        }
    }
}
