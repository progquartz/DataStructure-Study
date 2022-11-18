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
    class _2675
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int T = int.Parse(sr.ReadLine());
            for(int testcase = 0; testcase < T; testcase++)
            {
                string[] input = sr.ReadLine().Split();

                int R = int.Parse(input[0]);
                string str = input[1];

                for(int i = 0; i < str.Length; i++)
                {
                    for(int r = 0; r < R; r++)
                    {
                        sw.Write(str[i]);
                    }
                }
                sw.WriteLine();
            }
            sr.Close();
            sw.Close();
        }


    }


}
