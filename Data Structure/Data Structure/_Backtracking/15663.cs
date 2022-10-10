using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _15663
    {
        static int N, M;
        private static StreamWriter sb = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int[] arr; // 데이터가 쌓이는 부분.
        static int[] data;
        static bool[] check;
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
            int xx = 0;
            for (int i = 0; i < N; i++)
            {
                if(!check[i] && data[i] != xx)
                {
                    arr[count] = data[i];
                    xx = arr[count];
                    check[i] = true;
                    Backtracking(count + 1);
                    check[i] = false;
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
            check = new bool[N];

            Array.Sort(data);

            arr = new int[M];

            Backtracking(0);
            sb.Close();
            sr.Close();
        }
    }
}
