using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _3273
    {
        public void Solve()
        //static void Main(string[] args)
        {
            bool[] datas = new bool[2000001];
            int[] inputs = new int[1000001];
            int count = 0;

            int N = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split();
            for(int i = 0; i < N; i++)
            {
                datas[int.Parse(input[i])] = true; // 해당 지점에 방문했다는 리스트.
                inputs[i] = int.Parse(input[i]);
            }

            int X = int.Parse(Console.ReadLine());

            for(int i = 0; i < N; i++)
            {
                if(X - inputs[i] > 0 && datas[X - inputs[i]])
                {
                    count++;
                }
            }

            Console.WriteLine(count/2);
        }
    }
}
