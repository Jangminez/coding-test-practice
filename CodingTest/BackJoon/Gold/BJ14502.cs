namespace BackJoon
{
    class BackJoon14502 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            크기가 N x M 인 연구소에서 바이러스가 상하좌우로 퍼져나간다
            벽을 3개를 세워서 바이러스의 확산을 최대한 막고, 안전 영역의 최대값을 구해라

            ** 아이디어 ** 
            벽을 3개를 세우는 조합마다 (DFS, 백트래킹)
            BFS를 통해 바이러스 확산 -> 안전 영역 계산

            ** 시간 복잡도 **
            O(C(N x M, 3) x (N x M))
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] dx = { 1, 0, -1, 0 };
        static int[] dy = { 0, 1, 0, -1 };

        static int n, m;
        static int[,] map;
        static int maxCount;
        
        public void Solution()
        {
            int[] nm = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            n = nm[0];
            m = nm[1];

            map = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

                for (int j = 0; j < m; j++)
                {
                    map[i, j] = input[j];
                }
            }

            BuildWall(0);

            writer.WriteLine(maxCount);
            writer.Flush();
        }

        private void BuildWall(int count)
        {
            if (count == 3)
            {
                int[,] temp = SpreadVirus(map);
                maxCount = Math.Max(maxCount, CountSafeArea(temp));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i, j] == 0)
                    {
                        map[i, j] = 1;
                        BuildWall(count + 1);
                        map[i, j] = 0;
                    }
                }
            }
        }

        private bool IsInMap(int y, int x)
        {
            return y >= 0 && y < n && x >= 0 && x < m;
        }

        private int[,] SpreadVirus(int[,] map)
        {
            Queue<(int y, int x)> queue = new Queue<(int y, int x)>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i, j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                }
            }

            int[,] temp = new int[n, m];
            Array.Copy(map, temp, map.Length);

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int ny = cur.y + dy[i];
                    int nx = cur.x + dx[i];

                    if (IsInMap(ny, nx) && temp[ny, nx] == 0)
                    {
                        temp[ny, nx] = 2;
                        queue.Enqueue((ny, nx));
                    }
                }
            }

            return temp;
        }

        private int CountSafeArea(int[,] map)
        {
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i, j] == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}