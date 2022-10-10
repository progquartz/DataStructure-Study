using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _15666
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int[] data; // 초기에 받는 데이터.
        static int[] stock; // 쌓은 데이터.

        static int N;
        static int M;

        static void Backtracking(int count)
        {
            if (count == M) // 카운트가 가득 찼을 경우, 내보내버린다.
            {
                for (int i = 0; i < M; i++)
                {
                    sw.Write(stock[i] + " ");
                }
                sw.WriteLine();
                return;
            }
            int xx = 0;
            for (int i = 0; i < N; i++)
            { // data[i]가 xx와는 다르고, 
                if ((count == 0 || data[i] >= stock[count - 1]) && xx != data[i])
                {
                    stock[count] = data[i];
                    xx = data[i];
                    Backtracking(count + 1);
                }
            }
        }

        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

            int[] inputArr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            N = inputArr[0];
            M = inputArr[1];

            data = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            Array.Sort(data);
            stock = new int[M];

            Backtracking(0);

            sr.Close();
            sw.Close();
        }
    }
}
