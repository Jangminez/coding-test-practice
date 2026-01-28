namespace BackJoon
{
    class BackJoon1504 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1504 특정한 최단 경로
            방향성이 없는 그래프, 임의로 주어진 두 정점은 반드시 통과하여 최단거리를 구해라

            ** 아이디어 ** 
            그래프, 다익스트라
            각 구간의 거리를 다익스트라로 구하여 결과 값을 구한다

            ** 시간 복잡도 **
            O(E log V): 다익스트라 1회 시간 복잡도.
            O(3 * E log V).
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n, e;
        static List<(int end, int dist)>[] graph;

        static readonly long INF = 200000000;

        public void Solution()
        {
            int[] graphInfo = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            n = graphInfo[0];
            e = graphInfo[1];

            graph = new List<(int end, int dist)>[n + 1];

            for(int i = 1; i <= n; i++)
            {
                graph[i] = new List<(int end, int dist)>();
            }
            for (int i = 0; i < e; i++)
            {
                int[] graphInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

                graph[graphInput[0]].Add((graphInput[1], graphInput[2]));
                graph[graphInput[1]].Add((graphInput[0], graphInput[2]));
            }

            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int v1 = input[0];
            int v2 = input[1];

            long[] d1 = FindMinDist(1);
            long[] dv1 = FindMinDist(v1);
            long[] dv2 = FindMinDist(v2);

            long path1 = d1[v1] + dv1[v2] + dv2[n];
            long path2 = d1[v2] + dv2[v1] + dv1[n];

            long result = Math.Min(path1, path2);

            if(result >= INF) writer.WriteLine("-1");
            else writer.WriteLine(result);

            writer.Flush();
        }

        long[] FindMinDist(int start)
        {
            long[] dist = new long[n + 1];
            Array.Fill(dist, INF);

            var pq = new PriorityQueue<int, long>();
            dist[start] = 0;
            pq.Enqueue(start, 0);

            while(pq.Count > 0)
            {
                pq.TryDequeue(out int cur, out long d);

                if(dist[cur] < d) continue;

                foreach(var edge in graph[cur])
                {
                    long nextDist = d + edge.dist;

                    if(nextDist < dist[edge.end])
                    {
                        dist[edge.end] = nextDist;
                        pq.Enqueue(edge.end, nextDist);
                    }
                }
            }

            return dist;
        }
    }
}