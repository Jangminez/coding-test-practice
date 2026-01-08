namespace BackJoon
{
    class BackJoon1806 : IBackJoon
    {
        /*
            ** 문제 요약 **
            연속된 수들의 부분합 중에서 합이 S이상이 되는 것 중에서
            가장 짧은 부분합의 길이를 반환해라

            ** 필요 변수 **
            int n, s 입력 값
            int[] arr 수열 입력값
            int left, right 왼쪽, 오른쪽 인덱스
            int sum 현재 누적된 합
            int len 부분 수열 길이의 최소값

            ** 아이디어 ** 
            투 포인터를 활용하여
            조건에 맞게 수열 탐색
            합이 S보다 커지면 left++, 합이 S보다 작으면 right++
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int s = input[1];

            int[] arr = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int sum = 0;
            int left = 0, right = 0;
            int len = n + 1;

            while (true)
            {
                if (sum >= s)
                {
                    len = Math.Min(len, right - left);
                    sum -= arr[left++];
                }
                else if (right == n)
                {
                    break;
                }
                else
                {
                    sum += arr[right++];
                }
            }

            if (len == n + 1) len = 0;

            writer.WriteLine(len);
            writer.Flush();
        }
    }
}