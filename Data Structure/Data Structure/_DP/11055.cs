using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 실버 2
/// 백트래킹
/// 핵심 -> 1912번과 유사한 문제의 풀이가 어떻게 진행되어야 하는가.
/// </summary>
namespace Data_Structure
{
    class _11055
    {
        public void Solve()
        //static void Main(string[] args)
        {
            // data[i]는 자신을 기준으로 두었을때 가장 높을 수 있는 수를 특정한다.
            // data[i]는 a[i] + 이전의 수 중 자신보다 작은 수(m)의 data[m]을 가져온다.

            int N = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split();
            int[] data = new int[N + 1];
            int[] a = new int[N + 1];

            for(int i = 0; i < N; i++)
            {
                a[i] = int.Parse(input[i]);
            }

            for(int i = 0; i < N; i++)
            {
                // 역순 클라이밍
                int j = 0;
                int maxadd = 0; // maxadd개념을 이해할 수 있었어야 함.
                for(j = i; j >= 0; j--)
                {
                    if (a[j] < a[i] && maxadd < data[j])
                    {
                        //Console.WriteLine("maxadd" + maxadd);
                        //Console.WriteLine("a[" + j + "] = "  + a[j] + " / a[" + i + "] =  " + a[i]);
                        maxadd = data[j];
                    }
                }
                data[i] = a[i] + maxadd;
            }

            int max = int.MinValue;
            for (int i = 0; i < N; i++)
            {
                //Console.Write(data[i] + " ");
                if (data[i] > max)
                {
                    max = data[i];
                }
            }
            //Console.WriteLine();
            Console.WriteLine(max);
        }
    }
}
