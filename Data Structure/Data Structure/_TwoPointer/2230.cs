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
    class _2230
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static long[] data;
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            long[] arr = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long N = arr[0];
            long M = arr[1];

            data = new long[N+1];
            for(int i = 0; i < N; i++)
            {
                data[i] = long.Parse(sr.ReadLine());
            }

            data = data.Distinct().ToArray(); // 중복 제거.
            data[N] = long.MaxValue;
            Array.Sort(data);

            /*
             1 3 7 10 13 18 20
             min값이 존재한다면, 
             두 수의 차가 min보다 클 경우에는 왼쪽의 인덱스를 하나 끌어오기.
             만약 해당 값이 min값보다 작고, M 이상이면 min에 다시 들어감. 
             만약, 인덱스가 닿거나, m보다 작아진다면 다시 오른쪽의 인덱스를 늘리기.
            
             */
            long ans = long.MaxValue;
            int leftpointer = 0;
            int rightpointer = 0;

            while (leftpointer < N) // 가장 왼쪽의 포인터가 n보다 작을때
            {
                if (data[rightpointer] - data[leftpointer] < M) // 만약 우 - 좌가 M보다 작으면
                {
                    rightpointer++; // 우포인터 늘리기.
                    continue;
                }
                if (data[rightpointer] - data[leftpointer] == M) // 만약 같다면 그냥 그게 제일 작은거잖아?!
                {
                    Console.WriteLine(M);
                    return;
                }
                ans = Math.Min(ans, data[rightpointer] - data[leftpointer]);
                leftpointer++; // 만약 아니라면 좌포인터 늘리기.
            }
            Console.WriteLine(ans);

            sr.Close();
            sw.Close();
            return;
        }


    }


}
