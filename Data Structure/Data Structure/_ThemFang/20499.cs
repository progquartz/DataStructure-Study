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
    /// 아무래도 우리 팀 다리우스가 고수인 것 같다. 그의 $K/D/A$를 보고 그가 「진짜」인지 판별해 보자.

    /// 
    /// $K+A<D이거나 D = 0이면 그는 「가짜」이고, 그렇지 않으면 「진짜」이다.
    /// </summary>
    /// 
    class _20499
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int[] input = Array.ConvertAll( sr.ReadLine().Split('/'), int.Parse);
            int k = input[0];
            int d = input[1];
            int a = input[2];

            if(d == 0)
            {
                Console.WriteLine("hasu");
                return;
            }
            if(k+a < d)
            {
                Console.WriteLine("hasu");
                return;
            }
            else
            {
                Console.WriteLine("gosu");
                return;
            }
            

            sr.Close();
            sw.Close();
        }


    }


}
