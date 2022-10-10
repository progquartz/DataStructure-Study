using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _2447
    {
        static StringBuilder sb = new StringBuilder(); // stringbuilder를 통한 Writeline을 사용해야함. 이거 안쓰면 시간초과남. 인생.
        //에... 그 조건을 찾아버렸는데 어짜지
        //static void Main(string[] args)
        public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                    Fractal(x, y, n);
                sb.Append('\n');
            }
            Console.Write(sb.ToString());
        }

        static private void Fractal(int x, int y, int num)
        {
            if ((y / num) % 3 == 1 && (x / num) % 3 == 1)
            {
                sb.Append(' ');
            }
            else
            {
                if (num / 3 == 0)
                    sb.Append('*');
                else
                    Fractal(x, y, num / 3);
            }
        }
    }
}
