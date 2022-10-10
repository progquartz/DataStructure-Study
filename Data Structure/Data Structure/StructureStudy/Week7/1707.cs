using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 
     #include <iostream>
#include <vector>

#define X first
#define Y second

#define MAX 20001

using namespace std;


int K; // 테스트케이스 수
int V, E; //정점, 간선 수

int node[MAX]; //이분그래프 -> 1이 red, 2 blue
// int adj[20001][20001];// 인접행렬 -> 하니까 메모리 초과 ★★★★★★★★★

vector <int> adj[MAX]; //벡터를 담는 배열 생성


bool isTrue = true; // 이분그래프인지



void dfs(int cur, int prevColor){
    //색칠안했으면 색칠해줌
    if(node[cur] == 0){
            node[cur] = (prevColor)%2 + 1; // 1이면 2가 2이면 1이됨
    }
    //이미 색칠했으면 색 비교
    else if(node[cur] != 0){
        //만약 인접한 노드가 같은색이면 false
        if(node[cur] == prevColor){isTrue = false; return;}
        //같은 색만 아니면 그냥 종료
        else{
            return;
        }
    }
    //해당 노드와 인접한 노드가 없으면 바로 종료
    if(adj[cur].empty()) return;
    
    
    //다음 방문할 노드 -> 
    for(auto x : adj[cur]){
        dfs(x, node[cur]); //이어진 노드(to) prevColor는 현재 노드의색
    }

    return;
}


int main(){
    cin >> K;

    while(K--){

        cin >> V >> E;
        
        //쓴 값들 초기화해야함
        for(int i = 0; i<= V; i++){
            adj[i].clear(); //해당 adj 벡터 초기화
            node[i] = 0; //해당 노드 초기화
        }
        isTrue = true;
        
        //시작
        
        for(int i = 0; i<E; i++){
            int from, to;
            cin >> from >> to;
            adj[from].push_back(to);
            adj[to].push_back(from); // 양방향 그래프이기 때문
        }
        
        //모든 노드에 대해서
        for(int i = 1; i<=V; i++){
            if(node[i] != 0)continue;//이미 색칠한 노드는 제외
            dfs(i, 1); //처음 시작하는 root노드는 이전컬러가 1(red) 로 시작
        }
        
        if(isTrue){
            cout << "YES" << '\n';
        }else{
            cout << "NO" << '\n';
        }
        

        
    }
    
    
    return 0;
}
     */
namespace Data_Structure
{


    class _1707
    {
        public const int MAX = 20001;
        

        static int K;
        static int V;
        static int E;

        static int[] node = new int[MAX]; // 이분그래프들.
        static List<int>[] adj = new List<int>[MAX]; // 인접행렬로 할 경우 20001*20001만큼 써서 터지드라.
        


        static bool isTrue = true; // 이분그래프인지

        static void dfs(int cur, int prevColor)
        {
            //색칠안했으면 색칠해줌
            if (node[cur] == 0)
            {
                node[cur] = (prevColor) % 2 + 1; // 1이면 2가 2이면 1이됨
            }
            //이미 색칠했으면 색 비교
            else if (node[cur] != 0)
            {
                //만약 인접한 노드가 같은색이면 false
                if (node[cur] == prevColor) { isTrue = false; return; }
                //같은 색만 아니면 그냥 종료
                else
                {
                    return;
                }
            }
            //해당 노드와 인접한 노드가 없으면 바로 종료
            if (adj[cur].Count == 0) return;


            //다음 방문할 노드 -> 
            for (int x = 0; x < adj[cur].Count; x++)
            {
                int n = adj[cur][x];
                dfs(n, node[cur]); //이어진 노드(to) prevColor는 현재 노드의색
            }
        }


        //static void Main(string[] args)
        public void Solve()
        {
            
            K = int.Parse(Console.ReadLine());

            for(int cycle = 0; cycle < K; cycle++)
            {
                string[] input1 = Console.ReadLine().Split();
                V = int.Parse(input1[0]);
                E = int.Parse(input1[1]);

                for(int i = 0; i < MAX; i++)
                {
                    adj[i] = new List<int>();
                }

                for(int i = 0; i < E; i++)
                {
                    string[] input2 = Console.ReadLine().Split();
                    int from = int.Parse(input2[0]);
                    int to = int.Parse(input2[1]);
                    adj[from].Add(to);
                    adj[to].Add(from);
                }
                isTrue = true;

                //모든 노드에 대해서
                for (int i = 1; i <= V; i++)
                {
                    if (node[i] != 0) continue;//이미 색칠한 노드는 제외
                    dfs(i, 1); //처음 시작하는 root노드는 이전컬러가 1(red) 로 시작
                }


                if (isTrue)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }

                node = new int[MAX]; // 이분그래프들.
                adj = new List<int>[MAX]; // 인접행렬로 할 경우 20001*20001만큼 써서 터지드라.
            }
        }
    }
}
