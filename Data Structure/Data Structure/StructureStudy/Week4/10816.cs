using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _10816
    {
        //static void Main(string[] args)
        public void Solve()
        {

            int n = int.Parse(Console.ReadLine());
            string[] nstr = Console.ReadLine().Split();

            List<int> ndatas = new List<int>();

            foreach (string item in nstr)
                ndatas.Add(int.Parse(item));

            ndatas.Sort();

            int m = int.Parse(Console.ReadLine());

            string[] mstr = Console.ReadLine().Split();

            int[] result_arr = new int[mstr.Length]; // 1920과 다른 부분. 해당 부분에 높은 인덱스 - 낮은 인덱스를 써 그 개수를 확인.

            int lower, upper;
            for (int i = 0; i < m; i++)
            {
                lower = lower_binary(ndatas, int.Parse(mstr[i]), n); // 해당 숫자에 대한 낮은 인덱스를 취하는 함수.
                upper = upper_binary(ndatas, int.Parse(mstr[i]), n); // 해당 숫자에 대한 높은 인덱스를 취하는 함수.
                if (upper == n - 1 && ndatas[n - 1] == int.Parse(mstr[i])) // 예외 케이스
                    upper++;

                result_arr[i] = upper - lower;
            }

            StringBuilder sb = new StringBuilder(string.Join("\n", result_arr));

            Console.WriteLine(sb);
        }

        /// <summary>
        /// 리스트 내의 인덱스중 해당 값을 가짐과 동시에 가장 낮은 인덱스값을 가진 수를 리턴하는 함수.
        /// </summary>
        /// <param name="arr">함수</param>
        /// <param name="target">대상</param>
        /// <param name="size">크기</param>
        /// <returns></returns>
        static int lower_binary(List<int> arr, int target, int size) 
        {
            int mid, start, end;
            start = 0;
            end = size - 1;

            while (end > start)
            {
                mid = (start + end) / 2;
                if (arr[mid] >= target) // target과 mid가 같을 경우에 end를 mid로 두기에, 가장 앞의 인덱스가 마지막에 도출됨.
                    end = mid;
                else start = mid + 1;
            }
            return end;
        }

        /// <summary>
        /// 리스트 내의 인덱스중 해당 값을 가짐과 동시에 가장 높은 인덱스값을 가진 수를 리턴하는 함수.
        /// </summary>
        /// <param name="arr">함수</param>
        /// <param name="target">대상</param>
        /// <param name="size">크기</param>
        /// <returns></returns>
        static int upper_binary(List<int> arr, int target, int size)
        {
            int mid, start, end;
            start = 0;
            end = size - 1;

            while (end > start)
            {
                mid = (start + end) / 2;
                if (arr[mid] > target) // target과 mid가 같을 경우에 end를 mid로 두지 않기에, 가장 뒤의 인덱스가 마지막에 도출됨.
                    end = mid;
                else start = mid + 1;
            }
            return end;
        }
    }
}
