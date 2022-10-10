using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _1182
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int N;
        static int S;

        static int[] data;
        static int anscount = 0;
        static void tracking(int count, int total) // count는 몇번째를 가져가느냐에 대한 질문이며, total은 총합을 의미.
        {
            if(count == N)
            {
                if (total == S) // 이 조건이 성립해야지만 anscount가 올라가는것.
                {
                    anscount++;
                }
                return; // 어찌되었건간에 count가 N이면 종료는 되어야함.
            }

            tracking(count+1, total);
            tracking(count+1, total + data[count]);

        }
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            int[] inputArr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            N = inputArr[0];
            S = inputArr[1];

            data = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            
            tracking(0, 0);
            if (S == 0)
            {
                anscount--;
            }
            Console.WriteLine(anscount);

        }
    }
}
