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
    class _1987
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int W;
        static int H;

        static char[,] datas;
        static bool[,] visited;
        Stack<char> stack = new Stack<char>();

        static int DFS(int x, int y)
        {
            return 0;
        }
        public void Solve()
       //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            int[] input1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            H = input1[0];
            W = input1[1];

            datas = new char[W, H];
            visited = new bool[W, H];
            for(int y = 0; y < H; y++)
            {
                string input2 = sr.ReadLine();
                for(int x = 0; x < W; x++)
                {
                    datas[x, y] = input2[x];
                }
            }


            sr.Close();
            sw.Close();
        }


    }


}
