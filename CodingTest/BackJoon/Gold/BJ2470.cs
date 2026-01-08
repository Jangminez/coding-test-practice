namespace BackJoon
{
    class BackJoon2470 : IBackJoon
    {
        /*
            ** 문제 요약 **
            두 용액을 섞어 0에 가장 가까운 값을 찾아
            두 용액의 특성값을 반환하기

            ** 필요 변수 **
            int n 입력값
            int[] arr 용액의 특성 입력값
            int left, right 왼쪽, 오른쪽 인덱스
            int sum 용액의 값

            ** 아이디어 ** 
            1. 왼쪽, 오른쪽 인덱스를 움직이며 모든 경우를 우선순위 큐에 값을 저장 후 반환
                - 시간 복잡도: O(NlogN)
            2. 동일한 투 포인터 구조에 최소값을 저장할 변수에만 저장 후 반환
                - 시간 복잡도: O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());
            int[] arr = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            Array.Sort(arr);

            int left = 0;
            int right = n - 1;

            long minSum = long.MaxValue;
            (int l, int r) minSumLR = (0, n - 1);


            while (left < right)
            {
                int curSum = arr[left] + arr[right];

                if(Math.Abs(curSum) < minSum)
                {
                    minSum = Math.Abs(curSum);
                    minSumLR.l = left;
                    minSumLR.r = right;
                }

                if (curSum > 0) right--;
                else if (curSum < 0) left++;
                else break;
            }

            writer.WriteLine($"{arr[left]} {arr[right]}");
            writer.Flush();
        }

        public void Solution2()
        {
            int n = int.Parse(reader.ReadLine());
            int[] arr = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            Array.Sort(arr);

            int left = 0;
            int right = n - 1;

            long minSum = long.MaxValue;
            (int l, int r) minSumLR = (0, n - 1);


            while (left < right)
            {
                int curSum = arr[left] + arr[right];

                if (Math.Abs(curSum) < minSum)
                {
                    minSum = Math.Abs(curSum);
                    minSumLR.l = left;
                    minSumLR.r = right;
                }

                if (curSum == 0) break;
                else if (curSum > 0) right--;
                else left++;
            }

            writer.WriteLine($"{arr[minSumLR.l]} {arr[minSumLR.r]}");
            writer.Flush();
        }
    }
}