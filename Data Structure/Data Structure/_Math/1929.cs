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
    class _1929
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static bool[] visited = new bool[1000001];
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = input[0];
            int M = input[1];

            for(int i = 2; i <= M; i++)
            {
                if (!visited[i])
                {
                    int index = i;
                    while(index <= M)
                    {
                        visited[index] = true;
                        index += i;
                    }
                    if(i >= N)
                    {
                        sw.WriteLine(i);
                    }
                }
            }
            sr.Close();
            sw.Close();
        }


    }


}
