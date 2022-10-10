using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _2263
    {
        static StringBuilder sb = new StringBuilder();
        static int N;
        static int[] Index = new int[N + 2];
        static int[] inorder = new int[N + 2];
        static int[] postorder = new int[N + 2];


        static void SplitInorder(int inStart, int inEnd, int postStart, int postEnd)
        {
            //Console.WriteLine("새로운 Split / start :" + inStart + " / end : " + inEnd + " / root : " + postStart + "/ data :" + inorder[postStart]);

            if (inStart > inEnd || postStart > postEnd) // 예외처리해야 하는 경우는 그냥 return.
            {
                return;
            }
            
            // Index 배열을 통해 inorder에서의 root index를 쉽게 구할 수 있다.
            int rootIndex = Index[postorder[postEnd]];
            int leftSize = rootIndex - inStart;
            int rightSize = inEnd - rootIndex;
            sb.Append(inorder[rootIndex] + " ");

            // 재귀 함수 호출
            SplitInorder(inStart, rootIndex - 1, postStart, postStart + leftSize - 1);
            SplitInorder(rootIndex + 1, inEnd, postStart + leftSize, postEnd - 1);

        }
        // 분할 정복
        //static void Main(string[] args)
        public void Solve()
        {
            
            N = int.Parse(Console.ReadLine());

            Index = new int[N + 5]; // 인덱스는 인오더의 인덱스값을 저장함. 나중에 연산하기 쉬우라고...
            inorder = new int[N + 5];
            postorder = new int[N + 5];

            string a = " ";
            string[] input1 = Console.ReadLine().Split();
            

            for (int i = 1; i <= N; i++)
            {
                inorder[i] = int.Parse(input1[i-1]);
                Index[inorder[i]] = i;
            }

            string[] input2 = Console.ReadLine().Split();
            for (int i = 1; i <= N; i++)
            {
                postorder[i] = int.Parse(input2[i-1]);
            }

            SplitInorder(1,N,1,N);

            Console.WriteLine(sb.ToString());
        }
        
    }
}
