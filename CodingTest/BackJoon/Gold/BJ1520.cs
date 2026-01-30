namespace BackJoon
{
    class BackJoon1520 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1520 내리막길
            제일 왼쪽 위 지점에서 오른쪽 아래까지 항상 내리막길로 이동하는 경로의 개수를 구해라

            ** 아이디어 ** 
            DFS, DP
            DFS와 DP를 통해 dp[,]에 해당 지점에서 목적지까지 도달 가능한 경로 수 저장
            
            ** 시간 복잡도 **
            O(M * N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] dx = { 1, 0, -1, 0 };
        static int[] dy = { 0, 1, 0, -1 };

        static int m, n;
        static int[,] map;
        static int[,] dp;

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            m = input[0];
            n = input[1];

            map = new int[m, n];
            dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                int[] mapInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = mapInput[j];
                    dp[i, j] = -1;
                }
            }

            int result = DFS(0, 0);

            writer.WriteLine(result);
            writer.Flush();
        }

        public int DFS(int y, int x)
        {
            if (y == m - 1 && x == n - 1) return 1;
            if (dp[y, x] != -1) return dp[y, x];

            dp[y, x] = 0;

            for (int i = 0; i < 4; i++)
            {
                int ny = y + dy[i];
                int nx = x + dx[i];

                if (IsInMap(ny, nx) && map[ny, nx] < map[y, x])
                {
                    dp[y, x] += DFS(ny, nx);
                }
            }

            return dp[y, x];
        }

        public bool IsInMap(int y, int x)
        {
            return y >= 0 && y < m && x >= 0 && x < n;
        }
    }
}