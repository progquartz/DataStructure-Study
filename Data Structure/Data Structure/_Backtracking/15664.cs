using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{

    class _15664
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int[] data; // 처음에 받은 데이터.
        static int[] stock; // 데이터가 쌓이는 부분.
        static bool[] visited; // 방문 여부 체크.

        static int N; // 수열의 요소들.
        static int M; // 중복되는 순열의 길이.

        static void backTracking(int count) // n번째 자릿수를 정하는 함수.
        {
            if (count == M) // 만약 카운팅이 마무리된다면 이를 출력.
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
            {
                if ((count == 0 || data[i] >= stock[count - 1]) && !visited[i] && data[i] != xx)
                {
                    stock[count] = data[i];
                    xx = stock[count];
                    visited[i] = true;
                    backTracking(count + 1);
                    visited[i] = false;
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
            visited = new bool[N];


            Array.Sort(data);

            stock = new int[M];

            backTracking(0);
            sw.Close();
            sr.Close();

        }
    }
}
