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
    class _10798
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //public void Solve()
        static List<char>[] datas = new List<char>[15];
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            for(int i = 0; i < 15; i++)
            {
                datas[i] = new List<char>();
            }
            for(int i = 0; i < 5; i++)
            {
                string input = sr.ReadLine();
                for(int j = 0; j < input.Length; j++)
                {
                    datas[j].Add(input[j]);
                }
            }

            for(int i = 0; i < 15; i++)
            {
                if(datas[i].Count == 0)
                {
                    continue;
                }
                for(int j = 0; j < datas[i].Count; j++)
                {
                    Console.Write(datas[i][j]);
                }
            }

            sr.Close();
            sw.Close();
        }


    }


}
