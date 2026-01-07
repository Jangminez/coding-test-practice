namespace BackJoon
{
    class BackJoon2559 : IBackJoon
    {
        /*
            ** 문제 요약 **
            2559 수열
            한 수열에서 연속적인 며칠(K) 동안의 온도의 합이 가장 큰 값 구하기

            ** 필요 변수 **
            int n, k 입력값
            int[] temperatures 온도의 수열
            int maxTemp 온도의 합의 최대값
            int sum 현재 온도의 값

            ** 아이디어 ** 
            슬라이딩 윈도우
            처음 k까지 값을 더한 후
            for문에서 이전 값(temperatures[j - k])을 빼고 새로운 값(temperatures[j])을 더하며 진행

            시간 복잡도: O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int k = input[1];

            int[] temperatures = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += temperatures[i];
            }

            int maxTemp = sum;
            for (int j = k; j < n; j++)
            {
                sum -= temperatures[j - k];
                sum += temperatures[j];

                maxTemp = Math.Max(maxTemp, sum);
            }

            writer.WriteLine(maxTemp);
            writer.Flush();
        }
    }
}