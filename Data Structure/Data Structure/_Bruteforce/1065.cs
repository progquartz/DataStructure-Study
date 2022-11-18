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
    class _1065
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int N = int.Parse(sr.ReadLine());
            /*
            
             
             
             
             */
            int cnt = 0;
            for(int i = 1; i <= N; i++)
            {
                if(i / 10 == 0) // 첫번째 자리수일 경우.
                {
                    cnt++;
                    continue;
                }
                if(i/100 == 0) // 두 번째 자리수일 경우.
                {
                    cnt++;
                    continue;
                }
                if(i == 1000)
                {
                    continue;
                }
                int first = i / 100;
                int second = (i % 100) / 10; 
                int third = i % 10;
                if (first - second == second - third)
                {
                    cnt++;
                    continue;
                }
            }

            Console.WriteLine(cnt);
            sr.Close();
            sw.Close();
        }


    }


}
