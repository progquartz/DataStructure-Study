using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _1920
    {
        //static void Main(string[] args)
        public void Solve()
        {
            int N = int.Parse(Console.ReadLine()); // N 입력받기

            List<int> list = new List<int>();
            string[] str1 = Console.ReadLine().Split(); // 놀랍게도 입력형식때문에 N을 쓸 일은 없었다고 한다...

            foreach (string item in str1)
            {
                list.Add(int.Parse(item));
            }

            list.Sort(); // 이진 탐색을 위한 sort 사용.

            int M = int.Parse(Console.ReadLine());
            string[] str2 = Console.ReadLine().Split();

            int[] result_arr = new int[str2.Length];

            for (int i = 0; i < str2.Length; i++)
            {
                int search_item = int.Parse(str2[i]);

                int start = 0, end = list.Count - 1; //  start와 end를 선언
                int middle = 0; // middle을 선언

                while (true)
                {
                    middle = (start + end) / 2;
                    if (middle == start)
                    {
                        if (list[start] == search_item || list[end] == search_item) // result_arr에 결과 데이터를 저장.
                        {
                            result_arr[i] = 1; 
                        }
                        else
                        {
                            result_arr[i] = 0;
                        }
                        break;
                    }
                    else if (list[middle] == search_item)
                    {
                        result_arr[i] = 1;
                        break;
                    }
                    else if (list[middle] > search_item)
                    {
                        end = middle;
                    }
                    else if (list[middle] < search_item)
                    {
                        start = middle;
                    }
                    // 문제가 확정적으로 0과 1로만 나뉘는 문제기에 예외 처리는 없음.

                }
            }

            StringBuilder sb = new StringBuilder(string.Join("\n", result_arr)); // stringbuilder를 통한 Writeline을 사용해야함.
            
            Console.WriteLine(sb);
        }
    }
}
