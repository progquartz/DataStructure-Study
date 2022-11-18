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
    class _5648
    {
        static List<string> data = new List<string>();
        static List<long> longdata = new List<long>(); 
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int N;

        static string Reverse(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.

            string[] str = sr.ReadLine().Split();

            N = int.Parse(str[0]);

            int cnt = 0;
            int p = 0;
            for(int i = 1; i < str.Length && cnt < N; i++)
            {
                data.Add(str[i]);
                cnt++;
            }

            while (cnt < N)
            {
                string[] input1 = sr.ReadLine().Split();
                for (int i = 0; i < input1.Length; i++)
                {

                    data.Add(input1[i]);
                    cnt++;

                }

            }

            for(int i = 0; i < data.Count; i++)
            {
                long a = long.Parse(data[i]);
                string reverse = Reverse(a.ToString());
                longdata.Add(long.Parse(reverse));
            }

            longdata.Sort();

            for(int i = 0; i < longdata.Count; i++)
            {
                sw.WriteLine(longdata[i]);
            }

            sw.Close();
            sr.Close();
        }
    }


}
