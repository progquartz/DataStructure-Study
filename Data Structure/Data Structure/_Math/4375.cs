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
    class _4375
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
                string a = sr.ReadLine();
                if(a == null)
                {
                    break;
                }
                int N = int.Parse(a);
                int tmp = 0;
                for (int i = 1; i <= N; i++)
                {
                    tmp = tmp * 10 + 1;
                    tmp %= N;
                    if (tmp == 0)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
            


            sr.Close();
            sw.Close();
        }


    }


}
