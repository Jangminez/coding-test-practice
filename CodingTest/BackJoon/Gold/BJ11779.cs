namespace BackJoon
{
    class BackJoon11779 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            11779번 최소비용 구하기 2
            도시 A에서 B로 가는 최소 비용과 그 경로를 구해라

            ** 아이디어 ** 
            다익스트라, 역추적
            다익스트라로 최단 거리 구하기, 갱신 시점에 이전 노드 parent로 저장
            도착점에서 시작점까지 parent를 따라 거슬러 올라가며 역추적
            

            ** 시간 복잡도 **
            O(E logV)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n, m;
        static List<(int end, int cost)>[] graph;

        public void Solution()
        {
            n = int.Parse(reader.ReadLine());
            m = int.Parse(reader.ReadLine());

            graph = new List<(int end, int cost)>[n + 1];
            for(int i = 0; i <= n; i++)
            {
                graph[i] = new List<(int end, int cost)>();
            }

            for(int i = 0; i < m; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                int start = input[0];
                int end = input[1];
                int cost = input[2];

                graph[start].Add((end, cost));
            }

            int[] tempInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int s = tempInput[0];
            int e = tempInput[1];

            var result = FindMinPath(s, e, out int totalCost);
            
            writer.WriteLine(totalCost);
            writer.WriteLine(result.Count);
            
            while(result.Count > 0)
            {
                writer.Write($"{result.Pop()} ");
            }

            writer.Flush();
        }

        public Stack<int> FindMinPath(int start, int end, out int totalCost)
        {
            int INF = 100000001;
            int[] parent = new int[n + 1];
            int[] costs = new int[n + 1];

            Array.Fill(costs, INF);
            costs[start] = 0;

            var pq = new PriorityQueue<int, int>();
            pq.Enqueue(start, 0);

            while(pq.Count > 0)
            {
                pq.TryDequeue(out int cur, out int cost);

                if(costs[cur] < cost) continue;
                if(cur == end) break;

                foreach(var edge in graph[cur])
                {
                    int nextCost = edge.cost + cost;

                    if(nextCost < costs[edge.end])
                    {
                        parent[edge.end] = cur;
                        costs[edge.end] = nextCost;
                        pq.Enqueue(edge.end, nextCost);
                    }
                }
            }

            totalCost = costs[end];

            Stack<int> stack = new Stack<int>();
            int target = end;

            while(target != 0)
            {
                stack.Push(target);
                if(target == start) break;
                target = parent[target];    
            }

            return stack;
        }
    }
}