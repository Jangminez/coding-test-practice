namespace BackJoon
{
    class BackJoon16236 : IBackJoon
    {
        /*
            ** 문제 요약 **
            16236 아기 상어
            N x N 크기의 공간에 물고기 M마리 (Grid)
            아기 상어와 각 물고기는 크기를 가지고 있다. (시작 크기 2)
            자신보다 작은 물고기만 사냥 가능 (같은 물고기는 X, 이동은 가능)

            동작
            1. 더 이상 먹을 수 있는 물고기가 공간에 없다면 종료
            2. 먹을 수 있는 물고기가 1마리면 해당 물고기에게 이동
            3. 1 마리 이상이면 거리가 가장 가까운 물고기에게 이동
                3-1. 최단거리로 이동
                3-2. 거리가 가까운 물고기가 많다면, 가장 위, 가장 왼쪽 

            공간의 상태
            0: 빈 칸
            1 ~ 6: 물고기 크기
            9: 시작 위치

            크기와 같은 수의 물고기를 먹을 때 마다 크기 1 증가

            ** 필요 변수 **
            int n 공간의 크기
            int[,] map 공간에 대한 정보
            int curSize 아기 상어의 크기
            int curEat 현재 먹은 물고기 수
            int time 흐른 시간

            ** 아이디어 ** 
            시뮬레이션
            while 문에서 종료 조건까지 반복
            BFS를 통한 다음 물고기의 위치 탐색

            시간 복잡도
            BFS 탐색 : O(N^2)
            물고기 먹는 횟수: O(N^2)
            총합 : O(N^4)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n;
        static int[,] map;
        static int fishCnt = 0;

        static int curSize = 2;
        static int curEat = 0;
        static int x, y;

        static int time = 0;

        // 상, 좌, 하, 우
        static int[] dy = { -1, 0, 1, 0 };
        static int[] dx = { 0, -1, 0, 1 };

        public void Solution()
        {
            n = int.Parse(reader.ReadLine());

            map = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] mapInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = mapInput[j];

                    if (mapInput[j] >= 1 && mapInput[j] <= 6)
                    {
                        fishCnt++;
                    }
                    if (mapInput[j] == 9)
                    {
                        x = j;
                        y = i;

                        map[i, j] = 0;
                    }
                }
            }

            while (fishCnt > 0)
            {
                var next = BFS(y, x);

                if (next.dist == 0) break;

                x = next.x;
                y = next.y;
                time += next.dist;

                EatFish(y, x);
            }

            writer.WriteLine(time);
            writer.Flush();
        }

        public (int y, int x, int dist) BFS(int y, int x)
        {
            bool[,] visited = new bool[n, n];
            Queue<(int r, int c, int d)> queue = new Queue<(int r, int c, int d)>();

            visited[y, x] = true;
            queue.Enqueue((y, x, 0));

            List<(int r, int c, int d)> nearFishes = new List<(int r, int c, int d)>();
            int minDist = int.MaxValue;


            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                if (cur.d >= minDist) continue;

                for (int i = 0; i < 4; i++)
                {
                    int ny = cur.r + dy[i];
                    int nx = cur.c + dx[i];

                    if (IsInside(ny, nx) && CanMove(ny, nx, visited))
                    {
                        visited[ny, nx] = true;

                        if (CanEat(ny, nx))
                        {
                            minDist = cur.d + 1;
                            nearFishes.Add((ny, nx, cur.d + 1));
                        }

                        queue.Enqueue((ny, nx, cur.d + 1));
                    }
                }
            }

            if (nearFishes.Count == 0) return (-1, -1, 0);

            var target = nearFishes
                .OrderBy(f => f.r) // 상단 정렬
                .ThenBy(f => f.c) // 좌측 정렬
                .First();

            return target;
        }

        public void EatFish(int y, int x)
        {
            map[y, x] = 0;
            curEat++;
            fishCnt--;

            if (curEat == curSize)
            {
                curSize++;
                curEat = 0;
            }
        }

        public bool IsInside(int y, int x)
        {
            return y >= 0 && y < n && x >= 0 && x < n;
        }

        public bool CanEat(int y, int x)
        {
            return map[y, x] > 0 && map[y, x] < curSize;
        }

        public bool CanMove(int y, int x, bool[,] visited)
        {
            return !visited[y, x] && map[y, x] <= curSize;
        }
    }
}