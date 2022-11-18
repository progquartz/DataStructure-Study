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
    class _1541
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static public List<string> SplitByPlusMinus(string s)
        {
            s += " ";
            List<string> data = new List<string>();

            int first = 0;
            int length = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '+' || s[i] == '-' || s[i] == ' ')
                {
                    //Console.WriteLine(first + " " + length);
                    data.Add(s.Substring(first, length));
                    data.Add(s.Substring(i,1));
                    first = i + 1;
                    length = 0;
                }
                else
                {
                    length++;

                }
            }

            return data;
        }
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            string s = sr.ReadLine();
            List<string> sdata = SplitByPlusMinus(s);


            int answer = int.Parse(sdata[0]);
            bool flag = false;
            int tmp = 0;
            for (int i = 1; i < sdata.Count-1; i+=2)
            {
                if(sdata[i] == "-")
                {
                    flag = true;
                }

                if(flag == false)
                {
                    answer += int.Parse(sdata[i+1]);
                    tmp = 0;
                }
                else
                {
                    answer -= int.Parse(sdata[i+1]);
                    tmp = 0;
                }

            }

            Console.WriteLine(answer);

            sr.Close();
            sw.Close();
        }


    }


}
