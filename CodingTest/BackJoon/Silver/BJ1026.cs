namespace BackJoon
{
    class BackJoon : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1026 보물
            길이가 N인 배열 A, B 
            S = A[0] * B[0] + ..... + A[N - 1] * B[N - 1]
            S의 값을 가장 작게 만들기 위한 A의 수 재배열 후
            S의 최솟값을 구해라

            ** 필요 변수 **
            int n 입력값 배열의 자료 개수
            int[] a, b 각 입력값 배열
            PritorityQueue<int, int> pq b의 배열을 건드리지않고 값을 구하기 위한 우선순위 큐
            int sum 출력값을 담을 변수
 
            ** 아이디어 ** 
            출력값을 위해선 서로 오름차순, 내림차순으로 정렬해 모두 더하는 방식으로 구할 수 있지만
            문제의 조건인 b의 배열을 건들지 않고 값을 복사하여 우선순위 큐에 삽입
            전체 합 계산

            ** 시간 복잡도 **
            O(NlogN)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());
            int[] a = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int[] b = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            for (int i = 0; i < n; i++)
            {
                pq.Enqueue(b[i], -b[i]);
            }

            Array.Sort(a);

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += a[i] * pq.Dequeue();
            }

            writer.WriteLine(sum);
            writer.Flush();
        }
    }
}