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
    class _15964
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //public void Solve()

        static long SolveGolv(long a, long b)
        {
            return (a + b) * (a - b);
        }
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            // ＠으로, A＠B = (A+B)×(A-B)

            long[] input = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long A = input[0];
            long B = input[1];

            sw.WriteLine(SolveGolv(A, B));
            sr.Close();
            sw.Close();
        }


    }


}
