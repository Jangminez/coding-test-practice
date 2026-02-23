namespace BackJoon
{
    class BackJoon14891 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            14891 톱니바퀴
            8개의 톱니가 달린 4개의 톱니바퀴 하나를 돌릴 때 인접한 바퀴와 회전
            K번의 회전을 한 후 최종값을 구해라

            ** 아이디어 ** 
            배열을 직접 회전시키지않고, 톱니의 위쪽의 인덱스만 바꿔주며 관리
            시계 방향(1) 회전 시 TopIndex - 1, 반시계 방향(-1) 회전 시 TopIndex + 1;
            회전할 방향들을 계산하고, 마지막에 회전 수행

            ** 시간 복잡도 **
            O(K)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static readonly int LEFT_INDEX = 6;
        static readonly int RIGHT_INDEX = 2;

        static int[,] gears;
        static int[] topIndex;
        
        public void Solution()
        {
            gears = new int[4, 8];

            for (int i = 0; i < 4; i++)
            {
                string input = reader.ReadLine();

                for (int j = 0; j < input.Length; j++)
                {
                    gears[i, j] = input[j] - '0';
                }
            }

            int k = int.Parse(reader.ReadLine());
            topIndex = new int[4];

            for (int i = 0; i < k; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                int gear = input[0] - 1;
                int rotate = input[1];

                int[] rotations = new int[4];
                DetermineRotations(gear, rotate, rotations, new bool[4]);
                RotateGears(rotations);
            }

            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                if (gears[i, topIndex[i]] == 1)
                    result += (int)Math.Pow(2, i);
            }

            writer.WriteLine(result);
            writer.Flush();
        }

        private void DetermineRotations(int gear, int dir, int[] rotations, bool[] visited)
        {
            visited[gear] = true;
            rotations[gear] = dir;

            int left_gear = gear - 1;
            int right_gear = gear + 1;

            if (left_gear >= 0 && !visited[left_gear])
            {
                if (CanRotate(left_gear, gear))
                {
                    DetermineRotations(left_gear, -dir, rotations, visited);
                }
            }

            if (right_gear < 4 && !visited[right_gear])
            {
                if (CanRotate(gear, right_gear))
                {
                    DetermineRotations(right_gear, -dir, rotations, visited);
                }
            }

        }

        private bool CanRotate(int left, int right)
        {
            int right_side = (topIndex[left] + RIGHT_INDEX) % 8; 
            int left_side = (topIndex[right] + LEFT_INDEX) % 8;

            return gears[left, right_side] != gears[right, left_side];
        }

        private void RotateGears(int[] rotations)
        {
            for(int i = 0; i < 4; i++)
            {
                topIndex[i] = (topIndex[i] - rotations[i] + 8) % 8;
            }
        }
    }
}