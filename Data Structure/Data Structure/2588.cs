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
    class _2588
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            string input1 = sr.ReadLine();
            string input2 = sr.ReadLine();

            int a = int.Parse(input1);
            int b = int.Parse(input2);
            int b1 = int.Parse(input2[2].ToString());
            int b2 = int.Parse(input2[1].ToString());
            int b3 = int.Parse(input2[0].ToString());

            Console.WriteLine(a * b1);
            Console.WriteLine(a * b2);
            Console.WriteLine(a * b3);
            Console.WriteLine(a * b);
            sr.Close();
            sw.Close();
        }


    }


}
