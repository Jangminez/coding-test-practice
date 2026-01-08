namespace BackJoon
{
    class BackJoon2805 : IBackJoon
    {
        /*
            ** 문제 요약 **
            2805 나무 자르기
            나무 M 미터 필요, 절단기 높이 H 지정
            얻어가는 나무 = 나무의 높이 - 절단기 높이
            적어도 M미터의 나무를 집에 가져가기 위해 최대 H 값

            ** 필요 변수 **
            long n, m: 입력값 나무의 수, 필요한 나무 길이
            long[] trees: 나무들의 높이 배열 
            long start, end: 이분 탐색 범위
            long mid: 현재 절단기 높이
            long total: 나무 길이의 총합
 
            ** 아이디어 ** 
            매개변수 탐색, 이분 탐색
            total >= m : 
                현재 mid 값을 결과값에 저장, 더 높은 높이에서도 가능한지 확인 위해 범위를 높임 (start = mid + 1)
            total < m : 
                더 많이 잘라야 하므로 절단기 높이를 낮춤 (end = mid - 1)
            long 타입을 사용

            ** 시간 복잡도 **
            O(N log H)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            long[] input = Array.ConvertAll(reader.ReadLine().Split(' '), long.Parse);
            long n = input[0];
            long m = input[1];

            long[] trees = Array.ConvertAll(reader.ReadLine().Split(' '), long.Parse);

            long start = 0;
            long end = 0;
            foreach (long h in trees)
            {
                if (h > end)
                    end = h;
            }

            long result = 0;

            while (start <= end)
            {
                long mid = (start + end) / 2;
                long total = 0;

                foreach (var tree in trees)
                {
                    if (tree > mid) total += tree - mid;
                }

                if (total >= m)
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