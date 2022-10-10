using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _5639
    {
        static StringBuilder sb = new StringBuilder(); // stringbuilder를 통한 Writeline을 사용해야함. 이거 안쓰면 시간초과남. 인생.
        static int[] tree = new int[10005]; // 자기 부모도 있어야 함. // 0이 좌, 1가 우.

       
        static int i;

        static void post(int start, int end)
        {
            if (start >= end) return;

            for (i = start + 1; i < end; i++)
                if (tree[start] < tree[i]) break;

            post(start + 1, i);
            post(i, end);
            sb.AppendLine(tree[start].ToString());
            return;
        }

        //static void Main(string[] args)
        public void Solve()
        {
            int n = 0, x;

            while (true)
            {
                string input = Console.ReadLine();
                if(input == null)
                {
                    break;
                }
                tree[n++] = int.Parse(input);
            }

            post(0, n);

            Console.WriteLine(sb.ToString());
        }
    }
}
