namespace BackJoon
{
    class BackJoon15686 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            15686 치킨 배달
            0 = 빈 칸, 1 = 집, 2 = 치킨집
            치킨집을 최대 M개 골랐을 때 도시의 치킨 거리의 최솟값을 구해라
            치킨 거리 = 도시의 모든 집에서 가까운 치킨집까지의 거리의 합

            ** 아이디어 ** 

            
            ** 시간 복잡도 **
            O(M * N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int n, m;
        static List<(int y, int x)> homeList = new List<(int y, int x)>();
        static List<(int y, int x)> chickenList = new List<(int y, int x)>();


        static int minDist = int.MaxValue;

        static bool[] selected;

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            n = input[0];
            m = input[1];

            for (int i = 0; i < n; i++)
            {
                int[] mapInput = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < n; j++)
                {
                    if (mapInput[j] == 1) homeList.Add((i, j));
                    if (mapInput[j] == 2) chickenList.Add((i, j));
                }
            }

            selected = new bool[chickenList.Count];

            SelectChicken(0, 0);

            writer.WriteLine(minDist);
            writer.Flush();
        }

        private void SelectChicken(int start, int count)
        {
            if (count == m)
            {
                minDist = Math.Min(minDist, CalculateDist());
                return;
            }

            for (int i = start; i < chickenList.Count; i++)
            {
                selected[i] = true;
                SelectChicken(i + 1, count + 1);
                selected[i] = false;
            }
        }

        private int CalculateDist()
        {
            int total = 0;

            foreach (var home in homeList)
            {
                int minDist = int.MaxValue;

                for (int i = 0; i < chickenList.Count; i++)
                {
                    if (selected[i])
                    {
                        int dist = Math.Abs(chickenList[i].y - home.y) + Math.Abs(chickenList[i].x - home.x);
                        minDist = Math.Min(minDist, dist);
                    }
                }

                total += minDist;
            }

            return total;
        }
    }
}