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
    class _5376
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static Tuple<long,long> Abbreviation(long top, long bottom)
        {
            long euclid = Euclid(top, bottom);
            return new Tuple<long, long>(top / euclid, bottom / euclid);
        }

        static long Euclid(long top, long bottom)
        {
            /*
            1071은 1029로 나누어 떨어지지 않기 때문에, 1071을 1029로 나눈 나머지를 구한다. ≫ 42
            1029는 42로 나누어 떨어지지 않기 때문에, 1029를 42로 나눈 나머지를 구한다. ≫ 21
            42는 21로 나누어 떨어진다.
            */
            while (bottom % top != 0)
            {
                bottom = bottom % top;
                if(top > bottom)
                {
                    long temp = top;
                    top = bottom;
                    bottom = temp;
                }
            }
            return top;
        }

        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            long T = long.Parse(sr.ReadLine());

            for(long TestCase = 0; TestCase < T; TestCase++)
            {
                string input = sr.ReadLine();

                bool has_cycle = false;
                string cycle = null;
                string notcycle = null;
                for(int i = 2; i < input.Length; i++)
                {
                    if(input[i] == '(' || input[i] == ')')
                    {
                        has_cycle = true;
                        continue;
                    }
                    if (has_cycle)
                    {
                        cycle += input[i];
                    }
                    else
                    {
                        notcycle += input[i];
                    }
                }

                long top, bottom;
                if (notcycle == null)
                {
                    top = long.Parse(cycle);
                    bottom = (long)Math.Pow(10, cycle.Length) - 1;
                }
                else if (cycle != null)
                {
                    top = long.Parse(notcycle + cycle) - long.Parse(notcycle);
                    bottom = (long)Math.Pow(10, notcycle.Length + cycle.Length) - (long)Math.Pow(10, notcycle.Length);
                }
                else
                {
                    top = long.Parse(notcycle);
                    bottom = (long)Math.Pow(10, notcycle.Length);
                }
                

                Tuple<long, long> pair = Abbreviation(top, bottom);
                sw.WriteLine(pair.Item1 + "/" + pair.Item2);
            }
            sr.Close();
            sw.Close();
        }


    }


}
