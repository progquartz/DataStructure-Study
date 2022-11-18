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
    /// 
    struct LongCounter
    {
        public long number;
        public int count;
        public int appear;

        public LongCounter(long _number, int _count , int _appear)
        {
            number = _number;
            count = _count;
            appear = _appear;
        }

        public void ChangeCount(int _count)
        {
            count = _count;
        }
    }
    class _2910
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static List<LongCounter> data = new List<LongCounter>();
        static int N;
        static long C;
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.

            long[] input1 = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            N = int.Parse(input1[0].ToString());
            C = input1[1];

            long[] input2 = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            for(int i = 0; i < N; i++)
            {
                long tempdata = input2[i];
                bool foundsame = false;
                for(int index = 0; index < data.Count; index++)
                {
                    if(tempdata == data[index].number)
                    {
                        //Console.WriteLine("같은 숫자 발견" + tempdata + "이며 카운터를" + (data[index].count + 1) + "로 증가");
                        data[index] = new LongCounter(tempdata, data[index].count + 1, data[index].appear);
                        foundsame = true;
                        break;
                    }
                }
                if (!foundsame)
                {
                    //Console.WriteLine("처음으로 숫자 발견" + tempdata + "이며 " + i + "번째에 나타남.");
                    LongCounter tempcounter = new LongCounter(tempdata, 1, i);
                    data.Add(tempcounter);
                }
            }

            data.Sort((a,b) => {
                if (a.count == b.count)
                {
                    if (a.appear > b.appear)
                    {
                        return 1;
                    }
                    else if(a.appear < b.appear)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (a.count > b.count)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });

            for(int i = 0; i < data.Count; i++)
            {
                for(int j = 0; j < data[i].count; j++)
                {
                    sw.Write(data[i].number + " ");
                }
            }

            sw.Close();
            sr.Close();
        }
    }


}
