namespace BackJoon
{
    class BackJoon1753 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1753 최단 경로
            시작점에서 다른 모든 정점으로의 최단거리를 구해라

            ** 필요 변수 **
            int v, e 입력값 정점, 간선의 개수
            List<(int t, int w)> graph 각 노드의 연결정보 저장
            int[] dist 최단거리 저장
            PriorityQueue<int,int> queue 거리가 짧은 노드 먼저 꺼내기
 
            ** 아이디어 ** 
            출발 노드 설정,
            가장 짧은 노드 꺼낸 후 기존 거리보다 짧으면 dist 갱신

            ** 시간 복잡도 **
            O(E logV)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int v = input[0];
            int e = input[1];

            int startV = int.Parse(reader.ReadLine());

            List<(int t, int w)>[] graph = new List<(int t, int w)>[v + 1];
            for (int i = 0; i <= v; i++)
            {
                graph[i] = new List<(int t, int w)>();
            }

            for (int i = 0; i < e; i++)
            {
                int[] inputs = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                graph[inputs[0]].Add((inputs[1], inputs[2]));
            }

            int idx = 0;
            int[] dist = new int[v + 1];
            Array.Fill(dist, int.MaxValue);
            dist[startV] = 0;

            var queue = new PriorityQueue<int, int>();
            queue.Enqueue(startV, 0);

            while (queue.Count > 0)
            {
                var cur = queue.TryDequeue(out int curNode, out int curDist);

                if (curDist > dist[curNode]) continue;

                foreach (var edge in graph[curNode])
                {
                    int next = edge.t;
                    int weight = edge.w;

                    if (dist[curNode] + weight < dist[next])
                    {
                        dist[next] = dist[curNode] + weight;
                        queue.Enqueue(next, dist[next]);
                    }
                }
            }

            for (int i = 1; i <= v; i++)
            {
                if (dist[i] == int.MaxValue) writer.WriteLine("INF");
                else writer.WriteLine(dist[i]);
            }

            writer.Flush();
        }
    }
}