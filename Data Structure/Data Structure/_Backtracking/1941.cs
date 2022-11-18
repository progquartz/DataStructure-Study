using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    struct Vector2Int
    {
        public int x;
        public int y;

        public Vector2Int(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    class _1941
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static bool[] isVisited = new bool[25];
        static char[,] data = new char[5,5];
        static int[] dx = { 0, 0, 1, -1 };
        static int[] dy = { 1, -1, 0, 0 };

        static int answer = 0;

        static bool Adjacency()
        {
            Queue<Vector2Int> Q = new Queue<Vector2Int>();
            bool[,] Check_Select = new bool[5, 5];
            bool[,] Queue_Select = new bool[5, 5];
            bool Check_Answer = false;

            int Tmp = 0;
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (isVisited[i*5 + j] == true)
                    {
                        Check_Select[i,j] = true;
                        if (Tmp == 0)
                        {
                            Q.Enqueue(new Vector2Int(i, j));
                            Queue_Select[i,j] = true; Tmp++;
                        }
                    }
                }
            }

            int Cnt = 1;
            while (Q.Count != 0)
            {
                int x = Q.First().x;
                int y = Q.First().y;
                Q.Dequeue();
                if (Cnt == 7)
                {
                    Check_Answer = true;
                    break;
                }
                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];
                    if (nx >= 0 && ny >= 0 && nx < 5 && ny < 5)
                    {
                        if (Check_Select[nx,ny] == true && Queue_Select[nx,ny] == false)
                        {
                            Queue_Select[nx,ny] = true;
                            Q.Enqueue(new Vector2Int(nx, ny));
                            Cnt++;
                        }
                    }
                }
            }
            if (Check_Answer == true)
            {
                return true;
            }

            return false;

        }
        static int dummycount = 0;
        static void Tracking(int index, int Ycount, int Scount)
        {
            if(Ycount + Scount == 7)
            {
                if(Scount >= 4) // 만약 4명이 이 조합 내에 있다면.
                {
                    dummycount++;
                    
                    if (Adjacency()) // 해당 7명이 서로 인접해있는지를 확인.
                    {
                        answer++;
                    }
                    
                }
                return;
            }
            for(int i = index; i < 25; i++)
            {
                if (isVisited[i] == true)
                {
                    continue;
                }
                isVisited[i] = true;
                if (data[i/5,i%5] == 'Y')
                {
                    Tracking(i, Ycount + 1, Scount);
                }
                else
                {
                    Tracking(i, Ycount, Scount + 1);
                }
                isVisited[i] = false;
            }
        }
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())); // 만약 segfault오류나면 쓰지 말것.

            for(int i = 0; i < 5; i++)
            {
                string a = sr.ReadLine();
                for(int j = 0; j < 5; j++)
                {
                    data[i,j] = a[j];
                }
            }

            Tracking(0, 0, 0);
            Console.WriteLine(answer);
            


        }
    }
}
