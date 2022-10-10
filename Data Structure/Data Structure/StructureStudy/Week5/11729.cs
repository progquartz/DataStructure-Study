using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _11729
    {
        /*
         1. 어떤 개수의 무언가를 옮기는 경우 1칸을 움직이는 경우가 아니라면 그 경유점이 필요하다.
         2. 맨 아래의 블럭을 옮기기 위해서는 그 위의 모든 블럭들을 경유지로 옮겨야 함.
         3. 이를 도착시킨 다음에, 맨 아래의 블럭이 목적지로 옮겨지고, 그 위에 있었던 블럭들이 경유지에서 다시 목적지로 가는것이 재귀의 끝.
             
             */
        
        static StringBuilder sb = new StringBuilder(); // stringbuilder를 통한 Writeline을 사용해야함. 이거 안쓰면 시간초과남. 인생.
        static int count = 0;

        //static void Main(string[] args)
        public void Solve()
        {
            
            int n = int.Parse(Console.ReadLine());
            Hanoi(n, 1, 3, 2);
            Console.WriteLine(count);
            Console.Write(sb.ToString());

        }

        static private void Hanoi(int n, int start, int end, int way)
        {
            if (n == 1)
            {
                MovePosition(start, end);
            }
            else
            {
                Hanoi(n - 1, start, way, end); // 위의 블럭을 옮김.
                MovePosition(start, end);
                Hanoi(n - 1, way, end, start);
            }
        }

        static private void MovePosition(int start, int end)
        {
            sb.Append(start + " " + end + "\n");
            count++;
            //Console.WriteLine(start + " " + end); // 한칸을 움직이는 경우 이를 그냥 목적지로 움직임.
        }
    }
}
