using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class _1654
    {
        //static void Main(string[] args)
        public void Solve()
        {
            string[] input1 = Console.ReadLine().Split();
            int k = int.Parse(input1[0]);
            int n = int.Parse(input1[1]);

            List<ulong> length = new List<ulong>(); // int로 오버플로우남.
            for (int i = 0; i < k; i++)
            {
                length.Add(ulong.Parse(Console.ReadLine()));
            }

            ulong max = 0;
            for (int i = 0; i < length.Count; i++)
            {
                if (length[i] > max)
                    max = length[i];
            }

            ulong low = 1;
            ulong hi = max;

            // 파라매트릭 서치.
            /*
             이진탐색이 1부터 9까지의 값에서 3이라는 값을 찾는 알고리즘이라면 
             파라메트릭 서치는 1부터 9까지의 범위 내에서 3이라는 값(또는 원하는 조건에 부합하는 값)을 찾아가는 것이라는 차이가 있습니다. 
             따라서 주어진 값 중에서 탐색하는 이진탐색과는 다르게 파라메트릭 서치는 주어진 것이 값이 
             아니라 범위이기 때문에 특정한 상황을 최적화시키는 문제를 풀 때 용이하다는 장점을 가집니다.
            */
            while (low <= hi)
            // hi가 가장 긴 길이, low가 1인 상태에서, count는 length[i]이 mid값에 나눠지는 경우에 n과 가장 가까운 곳으로 수렴한다.
            // 이 문제가 성립하는 이유는, 길이가 짧아질수록 그 개수가 증가하기에 원하는 개수의 최대 길이가 파라매트릭 서치로 찾아지기 때문임.
            // 즉, 단순한 반비례 / 정비례의 경우가 아닌 경우는 파라매트릭 서치로 검색하는게 곤란해질 수 있음.
            {
                ulong count = 0;
                ulong mid = (low + hi) / 2;

                for (int i = 0; i < k; i++) { count += (length[i] / mid); }
                if (Convert.ToInt32(count) >= n) { low = mid + 1; }
                if (Convert.ToInt32(count) < n) { hi = mid - 1; }
            }
            Console.WriteLine(hi);
        }
    }
}
/*

    #include<iostream>
    using namespace std;

    int k, N;
    int length[10000];

    int main()
    {
        cin >> k >> N;
        for (int i = 0; i < k; i++) { cin >> length[i]; }

        long long low = 1;
        int hi = 1 << 31;
        hi--;
        while (low <= hi)
        {
            int count = 0;
            long long mid = (low + hi) / 2;

            for (int i = 0; i < k; i++) { count += (len[i] / mid); }
            if (count >= N) { low = mid + 1; }
            if (count < N) { hi = mid - 1; }
        }
        cout << hi;
    }
    */

