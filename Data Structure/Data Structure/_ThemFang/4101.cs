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
    class _4101
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            while (true)
            {
                
                int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int c = input[0];
                int b = input[1];

                if(c == 0 && b == 0)
                {
                    break;
                }
                if(c > b)
                {
                    sw.WriteLine("Yes");
                }
                else
                {
                    sw.WriteLine("No");
                }
            }
            sr.Close();
            sw.Close();
        }


    }


}
