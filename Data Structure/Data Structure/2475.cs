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
    class _2475
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            

            int[] array = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int num = 0;
            for(int i = 0; i < 5; i++)
            {
                num += array[i] * array[i];

            }
            Console.WriteLine(num % 10);
            sr.Close();
            sw.Close();
        }


    }


}
