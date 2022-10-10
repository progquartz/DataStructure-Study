using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  실버 1 문제.
/// </summary>
namespace Data_Structure
{
    class _1932
    {
        static List<List<int>> triangle;

        //static void Main(string[] args)
        static public void Solve()
        {
            int N;
            N = int.Parse(Console.ReadLine());
            triangle = new List<List<int>>();

            for (int i = 1; i <= N; i++)
            {
                triangle.Add(new List<int>());
            }

            string[] input1= Console.ReadLine().Split();
            triangle[0].Add(int.Parse(input1[0]));

            for (int i = 2; i <= N; i++)
            {
                string[] input2 = Console.ReadLine().Split();
                for(int j = 0; j < i; j++)
                {
                    if (j == 0) // 자신과 자신 바로 윗 열을 더함. 첫 인덱스일때.
                    {
                        triangle[i - 1].Add(int.Parse(input2[j]) + triangle[i - 2][j]);
                    }
                    else if (j+1 >= i) // 마지막 인덱스일때.
                    {
                        triangle[i - 1].Add(int.Parse(input2[j]) + triangle[i - 2][j - 1]);
                    }
                    else
                    {
                        int left = int.Parse(input2[j]) + triangle[i - 2][j];
                        int right = int.Parse(input2[j]) + triangle[i - 2][j - 1];
                        if(left > right)
                        {
                            triangle[i - 1].Add(left);
                        }
                        else
                        {
                            triangle[i - 1].Add(right);
                        }
                    }
                }
            }

            /*
            for(int i = 1; i <= N; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write(triangle[i-1][j] + " ");
                }
                Console.WriteLine();
            }
            */

            int max = 0;
            for(int i = 0; i < N; i++)
            {
                if(triangle[N-1][i] > max)
                {
                    max = triangle[N - 1][i];
                }
            }

            Console.WriteLine(max);

        }
    }
}
