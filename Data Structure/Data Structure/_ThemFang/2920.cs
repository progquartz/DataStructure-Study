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
    class _2920
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            bool isascending = true;
            bool isdescending = true;

            int[] datas = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int before = datas[0];
            for(int i = 1; i < datas.Length; i++)
            {
                if (before + 1 == datas[i] && isascending)
                {
                    isascending = true;
                }
                else
                {
                    isascending = false;
                }
                if(before-1 == datas[i] && isdescending)
                {
                    isdescending = true;
                }
                else
                {
                    isdescending = false;
                }
                before = datas[i];
            }
            if(!isdescending && !isascending)
            {
                Console.WriteLine("mixed");
            } 
            else if (isdescending)
            {
                Console.WriteLine("descending");
            }
            else if (isascending)
            {
                Console.WriteLine("ascending");
            }
            sr.Close();
            sw.Close();
        }


    }


}
