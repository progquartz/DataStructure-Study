using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    /// <summary>
    /// 이 문제 문제는 풀렸는데 문제이슈있음.
    /// </summary>
    class _1181
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int N;
        static List<string> data = new List<string>();
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.

            N = int.Parse(sr.ReadLine());

            for(int i = 0; i < N; i++)
            {
                data.Add(sr.ReadLine());
            }

            data.Sort((a, b) => {
                if (a.Length < b.Length)
                    return -1;
                else if (a.Length > b.Length)
                    return 1;
                else //a.Length == b.Length
                    return String.Compare(a, b);
            });

            data = data.Distinct().ToList();

            for(int i = 0; i < data.Count; i++)
            {
                sw.WriteLine(data[i]);
            }

            sw.Close();
            sr.Close();
        }
    }


}
