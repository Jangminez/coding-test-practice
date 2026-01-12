namespace BackJoon
{
    class BackJoon11047 : IBackJoon
    {
        /*
            ** 문제 요약 **
            11047 동전 0
            가지고 있는 동전의 종류 N
            동전들을 사용해서 합이 K가 되는데 필요한 동전의 최소 개수를 구해라

            ** 필요 변수 **
            int n, k 입력값 동전의 개수, 목표 금액
            int[] coins 입력받은 코인의 금액 배열
            int cnt 필요 동전 개수
            int idx 탐색할 인덱스
 
            ** 아이디어 ** 
            그리디 알고리즘
            오름차순으로 정렬된 자료가 입력되므로 뒤쪽 인덱스부터 K를 나눠 그 몫을 합한다.
            K == 0 이면 종료

            ** 시간 복잡도 **
            O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int k = input[1];

            int[] coins = new int[n];
            for(int i = 0; i < n; i++)
            {
                coins[i] = int.Parse(reader.ReadLine()); 
            }

            int cnt = 0;
            int idx = n - 1;
            while(k > 0)
            {
                cnt += k / coins[idx];
                k %= coins[idx--];
            }

            writer.WriteLine(cnt);
            writer.Flush();
        }
    }
}