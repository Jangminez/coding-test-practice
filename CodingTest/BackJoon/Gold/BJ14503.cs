namespace BackJoon
{
    class BackJoon14503 : IBackJoon
    {
        /*
            ** 문제 요약 **
            N x M 크기의 방
            청소기는 동, 서, 남, 북을 바라봄 1칸 씩 이동
            좌상단(0, 0), 우하단(N-1, M-1)

            로봇 청소기 조건
            1. 현재 칸이 청소되어있지 않으면, 현재 칸 청소
            2. 주변 4칸 중 청소할 칸이 없으면 
                2-1. 한 칸 후진할 수 있으면 후진 후 다시 1번
                2-2. 뒤쪽이 벽이면 작동 멈춤
            3. 주변 4칸 중 청소할 칸이 있다면
                3-1. 반시계 방향 회전(90)
                3-2. 앞에 청소할 칸이 있으면 전진
                3-3. 1번 반복

            ** 필요 변수 **
            int n, m 방의 크기
            int[,] room 방 배열
            int cnt 청소한 방의 개수 
            int r, c, dir 위치, 방향

            ** 아이디어 ** 
            시뮬레이션
            while문에서 위 구현 사항을 잘 구현

            시간 복잡도: O(N * M)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] dy = { -1, 0, 1, 0 };
        static int[] dx = { 0, 1, 0, -1 };

        static int n, m;
        static int[,] room;

        public void Solution()
        {
            int[] sizeInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            n = sizeInput[0];
            m = sizeInput[1];

            int[] robotInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int r = robotInput[0];
            int c = robotInput[1];
            int curDir = robotInput[2];

            room = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

                for (int j = 0; j < m; j++)
                {
                    room[i, j] = input[j];
                }
            }

            int cnt = 0;

            while (true)
            {
                if (room[r, c] == 0)
                {
                    room[r, c] = 2;
                    cnt++;
                }

                // 주변에 있는 경우
                if (HasAdjacent(r, c))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        curDir = curDir - 1 < 0 ? 3 : curDir - 1;

                        int nn = r + dy[curDir];
                        int nm = c + dx[curDir];

                        if (CanMove(nn, nm))
                        {
                            if (room[nn, nm] == 0)
                            {
                                r = nn;
                                c = nm;
                                break;
                            }
                        }
                    }

                    continue;
                }

                // 주변에 없는 경우
                else
                {
                    // 후진
                    int nn = r - dy[curDir];
                    int nm = c - dx[curDir];

                    if (CanMove(nn, nm))
                    {
                        r = nn;
                        c = nm;
                        continue;
                    }
                    else
                        break;
                }
            }

            writer.WriteLine(cnt);
            writer.Flush();
        }

        public bool HasAdjacent(int r, int c)
        {
            for (int i = 0; i < 4; i++)
            {
                int nn = r + dy[i];
                int nm = c + dx[i];

                if (CanMove(nn, nm))
                {
                    if (room[nn, nm] == 0)
                        return true;
                }
            }

            return false;
        }

        public bool CanMove(int r, int c)
        {
            return r >= 0 && r < n && c >= 0 && c < m && room[r, c] != 1;
        }
    }
}