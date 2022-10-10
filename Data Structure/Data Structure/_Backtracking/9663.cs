using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _9663
    {
        static bool[] isused1 = new bool[40];
        static bool[] isused2 = new bool[40];
        static bool[] isused3 = new bool[40];

        static int cnt = 0;
        static int n;
        static void func(int cur)
        {
            if (cur == n)
            {
                cnt++;
                return;
            }
            for(int i = 0; i < n; i++)
            {
                if(isused1[i] || isused2[i+cur] || isused3[cur - i + n - 1])
                {
                    continue;
                }
                isused1[i] = true;
                isused2[i + cur] = true;
                isused3[cur - i + n - 1] = true;
                func(cur + 1);
                isused1[i] = false;
                isused2[i + cur] = false;
                isused3[cur - i + n - 1] = false;

            }
        }
        public void Solve()
        //static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            func(0);
            Console.WriteLine(cnt);
        }
    }
}
