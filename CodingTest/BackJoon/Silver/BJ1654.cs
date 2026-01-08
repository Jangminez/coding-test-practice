namespace BackJoon
{
    class BackJoon1654 : IBackJoon
    {
        /*
            ** 문제 요약 **
            1654 랜선 자르기
            N개의 랜선을 만들어야함
            K개의 랜선을 모두 N 개의 같은 길이의 랜선으로 만드는 최대 랜선의 길이

            ** 필요 변수 **
            int k, n 입력값 가지고 있는 랜선의 개수, 만들어야할 랜선의 개수
            long start, end  탐색 범위
            long mid 랜선 현재 길이
            long total 랜선을 mid로 나눴을 때 총합
 
            ** 아이디어 ** 
            이분 탐색, 매개 변수 탐색
            특정 길이로 잘랐을 때 조각 수 확인
            total >= n 일때
                - 더 길게 가능한지 (start = mid + 1)
            total < n
                - 더 짧게 잘라야함 (end = mid - 1)

            ** 시간 복잡도 **
            O(K * logL)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int k = input[0];
            int n = input[1];

            long start = 1;
            long end = 0;

            int[] cables = new int[k];
            for (int i = 0; i < k; i++)
            {
                int cable = int.Parse(reader.ReadLine());
                cables[i] = cable;

                if (cable > end) end = cable;
            }

            long result = 0;

            while (start <= end)
            {
                long mid = (start + end) / 2;
                long total = 0;

                foreach (var cable in cables)
                {
                    total += cable / mid;
                }

                if (total >= n)
                {
                    result = mid;
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            writer.WriteLine(result);
            writer.Flush();
        }
    }
}