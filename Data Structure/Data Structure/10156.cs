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
    class _10156
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int k = input[0];
            int n = input[1];
            int m = input[2];

            if((k * n)-m  > 0)
            {
                Console.WriteLine((k * n) - m);

            }
            else
            {
                Console.WriteLine(0);
            }

            sr.Close();
            sw.Close();
        }


    }


}
