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
    class _1931
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        static int N;

        static List<Tuple<int,int>> datas = new List<Tuple<int,int>>();
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.

            N = int.Parse(sr.ReadLine());

            for(int i = 0; i < N; i++)
            {
                int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                Tuple<int, int> temp = new Tuple<int, int>(input[1], input[0]);
                datas.Add(temp);
            }

            datas.Sort();
            /*
            
            만약 A가 B보다 출발시간이 빠르고 도착시간이 빠르다면 무조건적으로 A가 더 좋다.


            항상 A는 B보다 출발시간이 같거나 빠를 것이니, 도착시간이 빠르면 무조건적으로 A가 좋음.
            만약 도착시간이 같다면 A가 더 좋음.

            만약 출발시간이 같다면, A가 무조건 더 좋음. O


            
            그러면, 도착시간이 B가 더 빠르면?
            B가 더 좋네?
            
            A입장에서 A를 안할때 그 직후에 잡히는 일정이 B니까...


            // 핷김.
            만약 도착시간이 B가 더 빠르다면, B가 더 좋음.

            그 외에는? A가 더 좋음.
            만약에 마지막의 끝났던 시간이 데이터의 시작점보다 더 늦게 된다면. 애초에 회의는 성립 불가능.


            
            */
            int cnt = 0;
            int nowEnding = 0;
            for(int i = 0; i < N; i++)
            {
                if(nowEnding > datas[i].Item2)
                {
                    continue;
                }
                cnt++;
                nowEnding = datas[i].Item1; //
            }

            Console.WriteLine(cnt);
        }


    }


}
