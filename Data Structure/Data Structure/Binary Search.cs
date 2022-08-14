using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class Binary_Search
    {

        public void Solve()
        {
            int[] datas = new int[] { 1, 2, 3, 5, 12, 13, 31, 53, 56 }; // 배열은 오름차순으로 이미 정렬되어있음.

            int result = BinarySearch(datas, 1);

            View(result);

            Console.ReadKey();

        }
        

        /// <summary>
        /// 이진 탐색을 수행한다.
        /// </summary>
        /// <param name="datas">배열</param>
        /// <param name="data">검색할 데이터</param>
        /// <returns></returns>
        private static int BinarySearch(int[] datas, int data)
        {
            int right = datas.Length - 1;
            for (int left = 0; left <= right;)
            {
                int middle = (left + right) / 2;
                switch (Compare(data, datas[middle]))
                {
                    case '>': left = middle + 1; break;//x>datas[middle] 
                    case '<': right = middle - 1; break;//x<datas[middle]
                    case '=': return middle; //x==datas[middle]
                }

            }
            //발견되지 않음
            return -1;
        }

        /// <summary>
        /// x와 y를 비교한다.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static char Compare(int x, int y)
        {
            if (x > y)
                return '>';
            else if (x < y)
                return '<';
            else
                return '=';
        }



        /// <summary>
        /// 화면에 출력한다.
        /// </summary>
        /// <param name="result"></param>
        private static void View(int result)
        {
            Console.Write("{0} ", result);
        }
    }

}
