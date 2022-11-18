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
    class _25238
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            double[] input = Array.ConvertAll(sr.ReadLine().Split(), double.Parse);

            double a = input[0];
            double b = input[1];

            if (a * (100 - b) / 100 >= 100) {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(1);
            }
            sr.Close();
            sw.Close();
        }


    }


}
