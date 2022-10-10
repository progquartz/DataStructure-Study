using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class IntToBin
    {
        //static void Main(string[] args)
        public void Solve()
        {

            int n = int.Parse(Console.ReadLine());

            Int_To_Bin(n);

        }

        static private int Int_To_Bin(int n) // 2진수 변환 함수
        {
            if (n == 0 || n == 1) // n의 값이 0또는 1이되면 n의 값을 출력
                Console.Write(n);
            else
            {
                Int_To_Bin(n / 2);
                Console.Write(n % 2);
            }
            return 0;
        }
    }
}
