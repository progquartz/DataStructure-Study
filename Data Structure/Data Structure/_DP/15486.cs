using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 14501번 실버 3
/// 백트래킹, 브루트포스
/// 
/// </summary>
namespace Data_Structure
{
    class _15486
    {
        // 계속해서 쌓이는 최대값을 구해서, 해당 날 기준 
        //payment[일 시작한 날 + 일하는 날]을 (일 시작한 날 기준 가장 돈 많이 벌 수 있는 경우 만큼 + 일해서 버는 값)으로 만들기. 경우를 구함.


        public void Solve()
        //static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] T = new int[1500100]; // 근로시간 초과의 경우.
            int[] P = new int[1500100]; // 근로시간 초과의 경우를 계산.
            long[] score = new long[1500100]; // 각 날짜 별 가장 돈 많이 벌었을 경우.
            for (int i = 1; i <= N; i++)
            {
                string[] input = Console.ReadLine().Split();
                T[i] = int.Parse(input[0]);
                P[i] = int.Parse(input[1]);
            }

            
            // 입력 종료.
            // 0일째에서 N-1까지 근무하는것으로 하기.
            for (int i = N; i >= 1; i--)
            {
                if (i + T[i] > N + 1)
                {
                    score[i] = score[i + 1];
                }
                else
                {
                    score[i] = Math.Max(score[i + 1], P[i] + score[i + T[i]]);
                }
            }

            Console.WriteLine(score[1]);

        }
    }
}
