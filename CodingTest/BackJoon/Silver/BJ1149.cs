namespace BackJoon
{
    class BackJoon1149 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1149 RGB 거리
            N개의 집, 거리는 선분으로 표시 1 ~ N 순서대로 존재
            집은 RGB 중 하나의 색을 칠하는 조건
            - 1번 집은 2번 집과 달라야함
            - N번의 집은 N - 1번 집의 색과 달라야함
            - i > 2 부터 양 옆의 집과 색이 달라야함
            모든 집을 칠하는 비용이 가장 작은 값을 구해라

 
            ** 아이디어 ** 
            DP
            이전 집을 다른 두 색으로 칠했을 때의 누적 최솟값
            점화식: r의 경우 dp[i, r] = Math.Min(costs[i - 1, g], costs[i - 1, b]) + costs[i, r];

            ** 시간 복잡도 **
            O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());

            int r = 0, g = 1, b = 2;
            int[,] costs = new int[n, 3];
            for (int i = 0; i < n; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                costs[i, r] = input[r];
                costs[i, g] = input[g];
                costs[i, b] = input[b];
            }

            int[,] dp = new int[n, 3];
            dp[0, r] = costs[0, r];
            dp[0, g] = costs[0, g];
            dp[0, b] = costs[0, b];

            for (int i = 1; i < n; i++)
            {
                dp[i, r] = Math.Min(dp[i - 1, g], dp[i - 1, b]) + costs[i, r];
                dp[i, g] = Math.Min(dp[i - 1, r], dp[i - 1, b]) + costs[i, g];
                dp[i, b] = Math.Min(dp[i - 1, r], dp[i - 1, g]) + costs[i, b];
            }

            int result = Math.Min(Math.Min(dp[n - 1, r], dp[n - 1, g]), dp[n - 1, b]);
            writer.WriteLine(result);
            writer.Flush();
        }
    }
}