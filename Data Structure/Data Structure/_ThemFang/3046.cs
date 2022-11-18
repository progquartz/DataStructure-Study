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
    class _3046
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int r1 = input[0];
            int s = input[1];

            // S = (r1+r2) / 2;
            // s = r1/2 + r2/2
            // r2/2 = s-r1/2
            // r2 = 2s - r1

            int r2 = (2 * s) - r1;
            Console.WriteLine(r2);
            sr.Close();
            sw.Close();
        }


    }


}
