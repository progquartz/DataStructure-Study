using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _6603
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int K;

        static int[] S;
        static int[] stacking;
        static void tracking(int cur, int selection) // 골라진 횟수.
        {
            if(cur == K) // 모든 경우를 해결했다면.
            {
                if(selection == 6) // 그리고 그 와중에 배열이 완성되었을때.
                {
                    for (int i = 0; i < 6; i++)
                    {
                        sw.Write(stacking[i] + " ");
                    }
                    sw.WriteLine();
                }
                return;
            }
            stacking[selection] = S[cur];
            tracking(cur + 1, selection + 1);

            tracking(cur + 1, selection);
            // 이번 인덱스를 고른 경우.
        }
        public void Solve()
        //static void Main(string[] args)
        {
            while (true)
            {
                sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

                int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                K = inputArr[0];
                if (K == 0)
                {
                    return;
                }
                S = inputArr.Skip(1).ToArray();

                stacking = new int[51];

                tracking(0, 0);
                sw.WriteLine();
                sw.Close();
            }
        }
    }
}
