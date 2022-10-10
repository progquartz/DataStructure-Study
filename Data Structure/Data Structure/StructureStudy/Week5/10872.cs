using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _10872
    {
        


        //static void Main(string[] args)
        public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        private int Factorial(int n)
        {
            if(n > 1)
            {
                return Factorial(n-1) * n;
            }
            else
            {
                return 1;
            }
        }
    }
}
