using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _15657
    {
        static int N, M;
        private static StreamWriter sb = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int[] arr; // 데이터가 쌓이는 부분.
        static int[] data;

        // 몇번째가 counting되었는지에 대한 이야기.
        static void Backtracking(int count)
        {
            if (count == M)
            {
                foreach (int i in arr)
                {
                    sb.Write(i + " ");
                }
                sb.WriteLine();
                return;
            }
            for (int i = 0; i < N; i++)
            {
                if(count == 0 || data[i] >= arr[count-1])
                {
                    arr[count] = data[i];
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

            arr = new int[M];

            Backtracking(0);
            sb.Close();
            sr.Close();
        }
    }
}
