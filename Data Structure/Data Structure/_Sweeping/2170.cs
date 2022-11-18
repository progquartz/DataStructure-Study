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
    /// 

    class _2170
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static List<int[]> datas = new List<int[]>();
        static int N;

        IComparable Compare(int[] a, int[] b)
        {
            if(a[0] < b[0])
            {
                return true;
            }
            return false;
        }
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            N = int.Parse(sr.ReadLine());

            for(int i = 0; i < N; i++)
            {
                int[] data = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                datas.Add(data);
            }

            datas = datas.OrderBy(x => x[0]).ToList();

            int answer = 0;
            int left = int.MinValue;
            int right = int.MinValue;
            
            for(int i = 0; i < N; i++)
            {
                if(datas[i][0] <= right)
                {
                    right = Math.Max(right, datas[i][1]);
                }
                else
                {
                    answer += right - left;
                    left = datas[i][0];
                    right = datas[i][1];
                }
            }
            answer += right - left;
            Console.WriteLine(answer);
        }


    }


}
