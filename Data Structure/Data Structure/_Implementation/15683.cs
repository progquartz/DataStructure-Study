using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    public enum Rot
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    class _15683
    {
        // 채워진 경우에는 -1로 처리.
        // 사용된 경우는 8로 처리.
        // dfs 형식의 재귀 방식?
        static int N;
        static int M;

        static List<List<int>> firstBlocks = new List<List<int>>();
        static List<List<int>> datas = new List<List<int>>();
        static List<int[]> lights = new List<int[]>();

        public void Solve()
        //static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();
            N = int.Parse(input1[0]); //세로 크기
            M = int.Parse(input1[1]); //가로 크기


            for(int y = 0; y < N; y++)
            {
                string[] input2 = Console.ReadLine().Split();
                firstBlocks.Add(new List<int>());
                datas.Add(new List<int>());
                for(int x = 0; x < M; x++)
                {
                    firstBlocks[y].Add(int.Parse(input2[x]));
                    datas[y].Add(int.Parse(input2[x]));
                }
            }

            // 출력 확인 완료

            LightenProblem();

            Console.WriteLine("-- fixeddata --");
            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < M; x++)
                {
                    Console.Write(datas[y][x] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("-- firstdata --");
            for (int y = 0; y < N; y++)
            {

                for (int x = 0; x < M; x++)
                {
                    Console.Write(firstBlocks[y][x] + " ");
                }
                Console.WriteLine();
            }


            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < M; x++)
                {
                    if (firstBlocks[y][x] >= 1 && firstBlocks[y][x] <= 5) // 만약 남아있는 빛이 존재한다면.
                    {
                        int[] array = new int[3]{y, x, firstBlocks[y][x]};
                        lights.Add(array);
                    }
                }
            }

            for(int i = 0; i < lights.Count; i++)
            {
                Console.WriteLine("(" + lights[i][2] + " / "+ lights[i][0] + "," + lights[i][1] + ")");
            }

        }

        // 문제 경량화를 위한 사전작업.
        // 10000 이하?
        static void LightenProblem()
        {
            // 모두 비출 수 있는 경우.
            if(firstBlocks[0][0] >= 3)
            {
                LockLightPosition(0, 0, Rot.DOWN);
                LockLightPosition(0, 0, Rot.RIGHT);
            }
            if(firstBlocks[0][M-1] >= 3)
            {
                LockLightPosition(0, M - 1, Rot.DOWN);
                LockLightPosition(0, M - 1, Rot.LEFT);
            }
            if(firstBlocks[N-1][0] >= 3)
            {
                LockLightPosition(N - 1, 0, Rot.UP);
                LockLightPosition(N - 1, 0, Rot.RIGHT);
            }
            if(firstBlocks[N-1][M-1] >= 3)
            {
                LockLightPosition(N - 1, M - 1, Rot.UP);
                LockLightPosition(N - 1, M - 1, Rot.LEFT);
            }

            if(N >= 3)
            {
                for (int y = 0; y < N; y++)
                {
                    if(firstBlocks[y][0] >= 4)
                    {
                        LockLightPosition(y, 0, Rot.UP);
                        LockLightPosition(y, 0, Rot.DOWN);
                        LockLightPosition(y, 0, Rot.RIGHT);
                    }
                    if(firstBlocks[y][M-1] >= 4)
                    {
                        LockLightPosition(y, M - 1, Rot.UP);
                        LockLightPosition(y, M - 1, Rot.DOWN);
                        LockLightPosition(y, M - 1, Rot.LEFT);
                    }
                }
            }
            // 가장자리. 
            if(M >= 3)
            {
                for (int x = 0; x < M; x++)
                {
                    if(firstBlocks[0][x] >= 4)
                    {
                        LockLightPosition(0, x, Rot.DOWN);
                        LockLightPosition(0, x, Rot.LEFT);
                        LockLightPosition(0, x, Rot.RIGHT);
                    }
                    if(firstBlocks[N-1][x] >= 4)
                    {
                        LockLightPosition(N - 1, x, Rot.UP);
                        LockLightPosition(N - 1, x, Rot.LEFT);
                        LockLightPosition(N - 1, x, Rot.RIGHT);
                    }
                }
            }

            for (int y = 0; y < N; y++)
            {

                for (int x = 0; x < M; x++)
                {
                    if(firstBlocks[y][x] == 5)
                    {
                        LockLightPosition(y, x, Rot.DOWN);
                        LockLightPosition(y, x, Rot.LEFT);
                        LockLightPosition(y, x, Rot.RIGHT);
                        LockLightPosition(y, x, Rot.UP);
                    }
                }
            }
        }

        static void LockLightPosition(int y, int x, Rot rotation)
        {
            Console.WriteLine(x + "," + y + "에서" + rotation + "방향으로 고정");
            firstBlocks[y][x] = 8;
            if (rotation == Rot.UP)
            {
                while (y > 0)
                {
                    y--;
                    if (datas[y][x] == 6)
                    {
                        break;
                    }
                    else if (datas[y][x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        datas[y][x] = -1;
                    }
                }
            }
            if (rotation == Rot.DOWN)
            {
                while (y < N - 1)
                {
                    y++;
                    if (datas[y][x] == 6)
                    {
                        break;
                    }
                    else if (datas[y][x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        datas[y][x] = -1;
                    }
                }
            }
            if (rotation == Rot.LEFT)
            {
                while (x > 0)
                {
                    x--;
                    if (datas[y][x] == 6)
                    {
                        break;
                    }
                    else if (datas[y][x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        datas[y][x] = -1;
                    }
                }
            }
            if (rotation == Rot.RIGHT)
            {
                while (x < M - 1)
                {
                    x++;
                    if (datas[y][x] == 6)
                    {
                        break;
                    }
                    else if (datas[y][x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        datas[y][x] = -1;
                    }
                }
            }
        }
        static void LightPosition(int y, int x, Rot rotation)
        {
            Console.WriteLine(x + "," + y + "에서" + rotation + "방향으로 비추기");
            if(rotation == Rot.UP)
            {
                while(y > 0)
                {
                    y--;
                    if(datas[y][x] == 6)
                    {
                        break;
                    }
                    else if(datas[y][x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        datas[y][x] = -1;
                    }
                }
            }
            if(rotation == Rot.DOWN)
            {
                while(y < N - 1)
                {
                    y++;
                    if (datas[y][x] == 6)
                    {
                        break;
                    }
                    else if (datas[y][x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        datas[y][x] = -1;
                    }
                }
            }
            if (rotation == Rot.LEFT)
            {
                while (x > 0)
                {
                    x--;
                    if (datas[y][x] == 6)
                    {
                        break;
                    }
                    else if (datas[y][x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        datas[y][x] = -1;
                    }
                }
            }
            if (rotation == Rot.RIGHT)
            {
                while (x < M - 1)
                {
                    x++;
                    if (datas[y][x] == 6)
                    {
                        break;
                    }
                    else if (datas[y][x] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        datas[y][x] = -1;
                    }
                }
            }
        }
    }
}
