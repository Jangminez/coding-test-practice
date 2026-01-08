namespace BackJoon
{
    class BackJoon2798 : IBackJoon
    {
        /*
            ** 문제 요약 **
            2798 블랙잭
            카드 N개에서 3장을 뽑아 M에 가장 가까운 합을 구해라

            ** 필요 변수 **
            int n, m 입력값 (카드의 수, 합의 근접해야하는 값)
            int[] cards 입력받는 카드의 배열
            int maxSum 최대 합
 
            ** 아이디어 ** 
            브루트 포스
            모든 카드의 수를 순회하면서
            M보다 작거나 같은 세 숫자의 합 중에서 제일 큰 값 찾기
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int m = input[1];

            int[] cards = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int maxSum = int.MinValue;

            for(int i = 0; i < n - 2; i++)
            {
                for(int j = i + 1; j < n -1; j++)
                {
                    for(int k = j + 1; k < n; k++)
                    {
                        int curSum = cards[i] + cards[j] + cards[k];
                        if(curSum <= m && curSum > maxSum)
                        {
                            maxSum = curSum;
                        }            
                    }
                }
            }

            writer.WriteLine(maxSum);
            writer.Flush();
        }
    }
}