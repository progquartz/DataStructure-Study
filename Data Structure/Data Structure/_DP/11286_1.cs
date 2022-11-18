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
    class _11286_1
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int N = 0;
        static int[] heap = new int[200000];
        static int pointer = 0;

        static void push(int num)
        {
            heap[++pointer] = num;
            int iter = pointer;
            int temp = 0;
            while (iter > 1)
            {
                if (Math.Abs(heap[iter]) == Math.Abs(heap[iter / 2]))
                {
                    if(heap[iter] < heap[iter / 2])
                    {
                        temp = heap[iter];
                        heap[iter] = heap[iter / 2];
                        heap[iter / 2] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
                else if(Math.Abs(heap[iter]) < Math.Abs(heap[iter / 2]))
                {
                    temp = heap[iter];
                    heap[iter] = heap[iter / 2];
                    heap[iter / 2] = temp;

                }
                else
                {
                    break;
                }
                iter /= 2;
            }
        }

        static void pop()
        {
            if (pointer > 0)
            {
                //Console.WriteLine(heap[1]);
                sw.WriteLine(heap[1]);
                heap[1] = heap[pointer--];
                int iter = 1;
                int temp = 0;
                int flag = 0;
                while (iter < pointer)
                {
                    flag = 0;
                    if (Math.Abs(heap[iter]) > Math.Abs(heap[iter * 2]) && iter * 2 <= pointer)
                    {
                        flag = 1;
                        if (Math.Abs(heap[iter * 2]) > Math.Abs(heap[iter * 2 + 1]) && iter * 2 + 1 <= pointer)
                        {
                            flag = 2;
                        }
                    }
                    else if (Math.Abs(heap[iter]) > Math.Abs(heap[iter * 2 + 1]) && iter * 2 + 1 <= pointer)
                    {
                        flag = 2;
                    }
                    if (flag == 0)
                        break;
                    else if (flag == 1)
                    {
                        iter *= 2;
                        temp = heap[iter];
                        heap[iter] = heap[iter / 2];
                        heap[iter / 2] = temp;
                    }
                    else
                    {
                        iter = iter * 2 + 1;
                        temp = heap[iter];
                        heap[iter] = heap[iter / 2];
                        heap[iter / 2] = temp;
                    }
                }
            }
            else
            {
                sw.WriteLine(0);
            }

        }
         public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            N = int.Parse(Console.ReadLine());
            int temp = 0;
            //heap[0] = int.MinValue;
            for (int i = 0; i < N; i++)
            {
                temp = int.Parse(Console.ReadLine());
                if (temp == 0)
                {
                    pop();
                }
                else
                {
                    push(temp);
                }
            }

            sw.Close();
            sr.Close();


        }

    }


}
