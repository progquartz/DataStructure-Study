using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    /// <summary>
    /// 현재 만들어놓은 
    /// </summary>
    class _1016
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static bool[] datas = new bool[1000001];
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            /*
             어떤 정수 X가 1보다 큰 제곱수로 나누어 떨어지지 않을 때, 그 수를 제곱ㄴㄴ수라고 한다.
             제곱수는 정수의 제곱이다.min과 max가 주어지면, min보다 크거나 같고, max보다 작거나 같은 제곱ㄴㄴ수가 몇 개 있는지 출력한다.
             
            ㄴㄴ수? => (max - min) -  어떤 정수 X가 1보다 큰 제곱수로 나누어 떨어진 수

            2의 제곱수로 나누어 떨어지지 않는다 -> 4로 나누어떨어지지 않는다.
            3의 제곱수로 나누어 떨어지지 않는다 -> 9로 나누어 떨어지지 않는다.

            */

            long min, max;
            long[] inputArr = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            min = inputArr[0];
            max = inputArr[1];

            for(long num = 2; num*num <= max; num++) // 소수인지를 확인하는 수.
            {
                long n = min / (num * num);

                if (min % (num * num) != 0) n++;

                while (n * num * num <= max)
                {       //n*i*i는 min보다 크거나 같은 i의 제곱수의 배수
                    datas[n * num * num - min] = true;
                    n++;
                }
            }

            int cnt = 0;
            for (int i = 0; i <= max - min; i++)
            {
                if (datas[i] == false) cnt++;
            }

            Console.WriteLine(cnt);

            sr.Close();
            sw.Close();
        }


    }
}
