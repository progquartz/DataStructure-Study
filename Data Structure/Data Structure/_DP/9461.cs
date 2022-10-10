using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 실버 2
/// 백트래킹
/// 핵심 -> long은 Int64로 해결하자. long으로도 됨. Convert64 ,
///         Convert32를 이용하는 법 익히기, 문제가 long일 수 있다는 생각 버리지 않기
/// </summary>
namespace Data_Structure
{
    
    class _9461
    {
        static List<Int64> datas = new List<Int64>();
        static void AddNormalData()
        {
            datas.Add(1);
            datas.Add(1);
            datas.Add(1);
            datas.Add(2);
            datas.Add(2);
        }   
        public void Solve()
        //static void Main(string[] args)
        {
            
            datas = new List<Int64>();
            AddNormalData();
            int howmuchhadgone = 5;
            
            Int64 T = Int64.Parse(Console.ReadLine());
            for(Int64 i = 0; i < T; i++)
            {
                int N = int.Parse(Console.ReadLine());
                if(N > howmuchhadgone)
                {
                    for(; howmuchhadgone <= N; howmuchhadgone++)
                    {
                        datas.Add(datas[ howmuchhadgone - 2] + datas[howmuchhadgone - 3]);
                    }
                }
                Console.WriteLine(datas[N-1]);
            }

        }
         
    }
}
