namespace BackJoon
{
    class BackJoon2003 : IBackJoon
    {
        /*
            ** 문제 요약 **
            2003 수들의 합 2
            N개의 수로 된 수열
            i번째 ~ j번째 수 까지의 합이 M이 되는 경우의 수를 구해라

            ** 필요 변수 **
            int n, m 입력값
            int sum 현재 수열의 합
            int cnt 조건에 맞는 개수
            int i, j 배열의 인덱스 (투 포인터)

            ** 아이디어 ** 
            2개의 인덱스를 가지고
            오른쪽 인덱스를 확장해가면서 수를 더해간다.
            sum >= m : 왼쪽 축소
            j == n : 값이 작은데 오른쪽 끝이라면 종료
            나머지 : 오른쪽 확장

            시간 복잡도 : O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int m = input[1];

            int[] nums = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int sum = 0, cnt = 0;
            int i = 0, j = 0;

            while (true)
            {
                if(sum >= m)
                {
                    sum -= nums[i++];
                }
                else if(j == n)
                {
                    break;
                }
                else
                {
                    sum += nums[j++];
                }

                if(sum == m) cnt++;
            }

            writer.WriteLine(cnt);
            writer.Flush();
        }
    }
}