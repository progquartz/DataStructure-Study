using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _10870
    {
        //static void Main(string[] args)
        public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibo(n));
        }

        private int Fibo(int n)
        {
            if (n == 0)
            {
                return 0;
                
            }
            else if(n == 1)
            {
                return 1;
            }
            else
            {
                return Fibo(n - 1) + Fibo(n-2);
            }
        }
    }
}
