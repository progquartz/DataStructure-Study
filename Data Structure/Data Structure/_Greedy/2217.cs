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
    class _2217
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int N;
        static List<int> datas = new List<int>();
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            N = int.Parse(sr.ReadLine());

            for(int i = 0; i < N; i++)
            {
                datas.Add(int.Parse(sr.ReadLine()));
            }

            datas.Sort();
            //datas.Reverse();

            /*
            
            만약 n개를 놓는다고 했을때 최선은 항상 가장 큰 걸 가지는 것이다. sum / n임.

            만약 n+1개를 놓을 때, sum + new / n + 1이 더 크면 이득.
             
            */

            int sum = 0;
            for (int i = 1; i <= N; i++)
            {
                sum = Math.Max(sum, datas[N - i] * i);
            }

            Console.WriteLine(sum);

            sr.Close();
            sw.Close();
        }


    }


}
