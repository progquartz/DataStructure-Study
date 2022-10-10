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
    class _14501
    {
        // 계속해서 쌓이는 최대값을 구해서, 해당 날 기준 
        //payment[일 시작한 날 + 일하는 날]을 (일 시작한 날 기준 가장 돈 많이 벌 수 있는 경우 만큼 + 일해서 버는 값)으로 만들기. 경우를 구함.

        
        public void Solve()
        //static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] T = new int[21]; // 근로시간 초과의 경우.
            int[] P = new int[21]; // 근로시간 초과의 경우를 계산.
            int[] score = new int[21]; // 각 날짜 별 가장 돈 많이 벌었을 경우.
            for(int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();
                T[i] = int.Parse(input[0]);
                P[i] = int.Parse(input[1]);
            }

            // 입력 종료.
            // 0일째에서 N-1까지 근무하는것으로 하기.
            for(int i = 0; i < N+1; i++)
            {
                int max = 0;
                //Console.Write(i + "번째");
                for(int j = i; j >= 0; j--)
                {
                    // 다음과 같이 하는 이유는 가장 마지막 열의 최댓값이 그 전까지의 최댓값과 같기 때문.
                    if (score[j] > max) 
                    {
                        max = score[j];
                    }
                    //Console.WriteLine(" max가 " + max + "였음");
                }
               
                
                // 일 시작한 시점 최대로 벌 수 있는 돈 + 벌게 될 돈이 일 끝날 시점 기준의 최대금보다 높다면.
                if (max + P[i] > score[i + T[i]])
                {
                    //Console.WriteLine(i + "번째를" +  max + "로 수정 ");
                    score[i] = max;
                    score[i + T[i]] = max + P[i];
                }
            }
       
            /*
            for(int i = 0; i < N+1; i++)
            {
                Console.Write(score[i] + " ");
            }
            */
            
            
            int answer = 0;
            for(int i = 0; i < N+1; i++)
            {
                if(score[i] > answer)
                {
                    answer = score[i];
                }
            }
            Console.Write(answer);
           
        }
    }
}
