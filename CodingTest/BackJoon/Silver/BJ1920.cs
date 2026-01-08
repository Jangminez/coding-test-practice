namespace BackJoon
{
    class BackJoon1920 : IBackJoon
    {
        /*
            ** 문제 요약 **
            1920 수 찾기
            N개의 정수가 주어졌을 때 X라는 정수가 존재하는지 알아내라

            ** 필요 변수 **
            int n 입력받은 숫자 배열의 크기
            int[] a 입력받은 숫자 배열
            int m 입력받은 확인할 숫자 배열의 크기
            int[] nums 존재 여부 확인할 숫자 배열
            HashSet<int> hash 숫자 배열을 추가하여 존재여부 판독하기 위함
 
            ** 아이디어 ** 
            1. HashSet 숫자들을 추가하고 확인할 숫자들을 빠르게 탐색하여 결과를 출력한다
            2. 숫자 배열 정렬 후, 이진탐색을 통한 빠른 탐색
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());
            int[] a = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int m = int.Parse(reader.ReadLine());
            int[] nums = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            HashSet<int> hash = new HashSet<int>(a);

            foreach (int num in nums)
            {
                if (hash.Contains(num))
                {
                    writer.WriteLine(1);
                    continue;
                }

                writer.WriteLine(0);
            }

            writer.Flush();
        }

        public void Solution2()
        {
            int n = int.Parse(reader.ReadLine());
            int[] a = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            int m = int.Parse(reader.ReadLine());
            int[] nums = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            Array.Sort(a);

            foreach (int num in nums)
            {
                BinarySearch(a, 0, n - 1, num);
            }

            writer.Flush();
        }

        public void BinarySearch(int[] arr, int start, int end, int target)
        {
            if (start > end)
            {
                writer.WriteLine(0);
                return;
            }

            int mid = (start + end) / 2;

            if (arr[mid] == target)
                writer.WriteLine(1);
            else if (arr[mid] < target)
                BinarySearch(arr, mid + 1, end, target);
            else
                BinarySearch(arr, start, mid - 1, target);
        }
    }
}