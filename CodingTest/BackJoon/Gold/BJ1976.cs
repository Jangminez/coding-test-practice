namespace BackJoon
{
    class BackJoon1976 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1976 여행 가자
            N개의 도시, 여행 경로가 가능한지 확인하기 (도시가 연결 되어 있는지)

            ** 아이디어 ** 
            Union-Find
            Union: 두 도시의 집합 연결
            Find: 각 도시의 대표 노드 탐색 (탐색하며 경로 압축)   

            ** 시간 복잡도 **
            O(N² + M)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] roads;

        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());
            int m = int.Parse(reader.ReadLine());

            roads = new int[n + 1];
            for (int i = 0; i < n + 1; i++) roads[i] = i;

            for (int i = 1; i <= n; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                for (int j = 1; j <= n; j++)
                {
                    if (input[j - 1] == 1)
                    {
                        Union(i, j);
                    }
                }
            }

            int[] path = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            bool isValid = true;
            for (int i = 0; i < m - 1; i++)
            {
                int rootA = Find(path[i]);
                int rootB = Find(path[i + 1]);

                if (rootA != rootB)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid) writer.WriteLine("YES");
            else writer.WriteLine("NO");
            writer.Flush();
        }

        private int Find(int x)
        {
            if (roads[x] == x) return x;
            return roads[x] = Find(roads[x]);
        }

        private void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                roads[rootB] = rootA;
            }
        }
    }
}