using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _2805
    {
        //static void Main(string[] args)
        public void Solve()
        {
            string[] input1 = Console.ReadLine().Split();
            int k = int.Parse(input1[0]);
            int n = int.Parse(input1[1]);

            List<long> length = new List<long>();
            string[] str1 = Console.ReadLine().Split();
            foreach (string item in str1)
            {
                length.Add(long.Parse(item));
            }

            long max = 0;
            for (int i = 0; i < length.Count; i++)
            {
                if (length[i] > max)
                    max = length[i];
            }

            long low = 1;
            long hi = max;

            // 똑같이 파라매트릭 서치를 사용했으며, 이번에는 그 조건이 나무를 베어냈을때 베어낸 양이 count만큼을 충족하는 경우임.
            // 더 많이 베어낼수록 베어낸 양이 정비례로 증가하므로, 파라매트릭 서치가 성립됨.
            while (low <= hi)
            {
                long count = 0;
                long mid = (low + hi) / 2;

                for (int i = 0; i < k; i++)
                {
                    if(length[i] - mid > 0)
                    {
                        count += (length[i] - mid);
                    }
                }
                if (count >= n) { low = mid + 1; }
                if (count < n) { hi = mid - 1; }
            }
            Console.WriteLine(hi);
        }
    }
}
