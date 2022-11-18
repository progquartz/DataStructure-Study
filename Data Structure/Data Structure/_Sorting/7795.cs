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
    class _7795
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int T;
        static int M;
        static int N;

        static List<int> AList = new List<int>();
        static List<int> BList = new List<int>();

        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.

            T = int.Parse(sr.ReadLine());
            for(int loop = 0; loop < T; loop++)
            {
                int[] input1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                N = input1[0];
                M = input1[1];
                AList = new List<int>();
                BList = new List<int>();

                int[] input2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int i = 0; i < N; i++)
                {
                    AList.Add(input2[i]);
                }

                int[] input3 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for(int i = 0; i < M; i++)
                {
                    BList.Add(input3[i]);
                }

                AList.Sort();
                BList.Sort();

                int ans = 0, point = 0;
                for (int i = 0; i < N; i++) // 모든 alist에 대하여...
                {
                    while ((point < M) && (AList[i] > BList[point])) // point가 m보다 작을 동안에만 (최대) 만약 alist의 원소가 blist의 point보다 클 경우에만 point가 오름.
                        point++;
                    ans += point; // 정답에 포인트만큼을 추가. (만약 a가 3인데 b에 1,1,2면 point가 3이 될거고 3개 먹은거니까.)
                }

                Console.WriteLine(ans);
            }
        }
    }


}
