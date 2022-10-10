using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _2110
    {
        //static void Main(string[] args)
        public void Solve()
        {
            string[] input1 = Console.ReadLine().Split();

            int n = int.Parse(input1[0]);
            int c = int.Parse(input1[1]);

            List<int> house = new List<int>();
            for (int i = 0; i < n; i++)
            {
                house.Add(int.Parse(Console.ReadLine()));
            }

            house.Sort();

            int mingap = 1; // 둘 사이의 최대 거리가 될 수 있는 경우 (거리 1)
            int maxgap = house.Max() - house.Min(); // 최대 범위를 설정함. (가장 앞의 집과 가장 뒤의 집 사이의 거리)

            while (mingap <= maxgap)
            {
                int mid = (mingap + maxgap) / 2;
                int standard = 0;
                int cnt = 1;

                for (int i = 0; i < n; i++)
                {
                    // 조건은 c 이하의 개수의 공유기를 설치하면서 가장 짧은 공유기 사이 거리가 최대가 되는 경우.
                    // 만약 두 거리사이의 공유기 거리가 mid보다 커질 경우 나눈것으로 판정나, 이에 대한 cnt를 c보다 큰지, 작은지 확인.
                    // 두 사이의 공유기 거리가 커질수록, 나눠지는 공유기의 수가 무조건적으로 작아지기에, 이는 파라매트릭 서치가 가능하다.
                    if (house[i] - house[standard] >= mid) 
                    {
                        cnt += 1;
                        standard = i;
                    }
                }
                if (cnt < c)
                {
                    maxgap = mid - 1;
                }
                else
                {
                    mingap = mid + 1;
                }
            }

            Console.WriteLine((mingap + maxgap) / 2);
        }
    }
}