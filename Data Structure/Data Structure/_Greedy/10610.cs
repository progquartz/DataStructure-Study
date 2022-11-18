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
    class _10610
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            string a = sr.ReadLine();


            char[] chars = a.ToCharArray();
            int[] datas = new int[chars.Length];
            for(int i = 0; i < chars.Length; i++)
            {
                datas[i] = int.Parse(chars[i].ToString());
            }
            
            Array.Sort(datas);
            Array.Reverse(datas);

            int sum = 0;
            bool ispossible = false;

            for (int i = 0; i < datas.Length; i++)
            {
                sum += datas[i];
                sum %= 3;
                if(datas[i] == 0)
                {
                    ispossible = true;
                }
            }
            if(sum % 3 == 0 && ispossible)
            {
                for (int i = 0; i < datas.Length; i++)
                {
                    sw.Write(datas[i]);
                }
            }
            else
            {
                Console.WriteLine(-1);
            }

            sr.Close();
            sw.Close();
        }


    }


}
