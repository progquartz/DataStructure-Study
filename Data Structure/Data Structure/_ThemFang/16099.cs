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
    class _16099
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int testcase = int.Parse(sr.ReadLine());
            
            for(int t = 0; t < testcase; t++)
            {
                    
                UInt64[] datas = Array.ConvertAll(sr.ReadLine().Split(), UInt64.Parse);
                UInt64 a1 = datas[0];
                UInt64 a2 = datas[1];
                UInt64 b1 = datas[2];
                UInt64 b2 = datas[3];

                if(a1 * a2 > b1 * b2)
                {
                    sw.WriteLine("TelecomParisTech");
                }
                else if(a1 * a2 < b1 * b2)
                {
                    sw.WriteLine  ("Eurecom");
                }
                else
                {
                    sw.WriteLine("Tie");
                }
            }
            sr.Close();
            sw.Close();
        }


    }


}
