namespace BackJoon
{
    class BackJoon2110 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            2110 공유기 설치
            C개의 공유기를 N개의 집에 적당히 설치해서, 가장 인접한 두 공유기 사이의 거리의 최대를 구해라

            ** 아이디어 ** 
            매개변수 탐색 (이분 탐색)
            두 공유기 사이의 거리를 기준으로 이분 탐색 수행

            ** 시간 복잡도 **
            O(N log N + N * log(1,000,000,000))
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        public void Solution()
        {
            int[] nc = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = nc[0];
            int c = nc[1];

            int[] home = new int[n];
            for (int i = 0; i < n; i++)
            {
                home[i] = int.Parse(reader.ReadLine());
            }

            Array.Sort(home);

            int min = 1;
            int max = home[n - 1] - home[0];
            int result = 0;

            while(min <= max)
            {
                int mid = (min + max) / 2;

                if(CanInstall(home, mid, c))
                {
                    result = mid;
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }

            writer.WriteLine(result);
            writer.Flush();
        }

        private bool CanInstall(int[] home, int dist, int count)
        {
            count--;
            int curInstall = home[0];

            for(int i = 1; i < home.Length; i++)
            {
                if(home[i] - curInstall >= dist)
                {
                    curInstall = home[i];
                    count--;
                }
                
                if(count == 0) return true;
            }

            return false;
        }
    }
}