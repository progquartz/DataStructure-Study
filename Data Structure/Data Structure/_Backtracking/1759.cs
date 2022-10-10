using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _1759
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int L; // length
        static int C; // chars
        static char[] data;
        static char[] stacking;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="constants">자음</param>
        /// <param name="vowel">모음.</param>
        static void Tracking(int index, int constants, int vowel)
        {
            if(index == C)
            {
                if(constants >= 2 && vowel >= 1 && constants + vowel == L)
                {
                    for(int i = 0; i < L; i++)
                    {
                        sw.Write(stacking[i]);
                    }
                    sw.WriteLine();
                }
                return;
            }

            if (data[index] == 'a' || data[index] == 'e' || data[index] == 'i' || data[index] == 'o' || data[index] == 'u')
            {
                stacking[constants + vowel] = data[index];
                Tracking(index + 1, constants, vowel + 1);
            } // 자음일 경우.
            else
            {
                stacking[constants + vowel] = data[index];
                Tracking(index + 1, constants + 1, vowel);

            }
            // 이번걸 안넣는데...
            Tracking(index + 1, constants, vowel);
            // 이번걸 넣는데...
            // 모음일 경우

        }

        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.

            int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            L = inputArr[0];
            C = inputArr[1];

            data = Array.ConvertAll(Console.ReadLine().Split(), char.Parse);

            Array.Sort(data);

            stacking = new char[C];
            Tracking(0, 0, 0);
            sw.Close();
            sr.Close();
        }
    }
}
