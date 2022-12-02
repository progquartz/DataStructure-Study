using System;
using System.IO;

namespace Data_Structure
{
    class _2630
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //public void Solve()
        static int[,] datas;
        static int N;

        /*
		만약 문제 내에서 주어진 데이터들이 있으면 이들이 모두 같은지 확인하고,같다면 1을 리턴하고 다르다면 
		자르기를 시전해서 4등분으로 한 다음 이들의 합을 구해서 그 합을 다시리턴하는 함수.
		*/
        static int[] RunAll(int startx, int starty, int size)
        {
            int first = datas[startx, starty];
            bool isallsame = true;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (datas[startx + x, starty + y] != first)
                    {
                        isallsame = false;
                        break;
                    }

                }
                if (!isallsame)
                {
                    break;
                }
            }

            if (isallsame)
            {
                if (first == 0)
                {
                    return new int[2] { 1, 0 };
                }
                else
                {
                    return new int[2] { 0, 1 };
                }
            }
            else
            {
                // 네 조각으로 나누어서 각 수를 더하기
                int sumwhite = 0;
                int sumblue = 0;
                int[] case1 = RunAll(startx, starty, size / 2);
                sumwhite += case1[0];
                sumblue += case1[1];
                int[] case2 = RunAll(startx + size / 2, starty, size / 2);
                sumwhite += case2[0];
                sumblue += case2[1];
                int[] case3 = RunAll(startx, starty + size / 2, size / 2);
                sumwhite += case3[0];
                sumblue += case3[1];
                int[] case4 = RunAll(startx + size / 2, starty + size / 2, size / 2);
                sumwhite += case4[0];
                sumblue += case4[1];

                return new int[2] { sumwhite, sumblue };
            }
        }

        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

            N = int.Parse((sr.ReadLine()));

            datas = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                int[] array = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int y = 0; y < N; y++)
                {
                    datas[y, i] = array[y];
                }
            }


            int[] ans = RunAll(0, 0, N);
            Console.WriteLine(ans[0]);
            Console.WriteLine(ans[1]);


            sr.Close();
            sw.Close();
        }


    }


}