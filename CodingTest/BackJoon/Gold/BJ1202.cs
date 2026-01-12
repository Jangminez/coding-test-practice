namespace BackJoon
{
    class BackJoon1202 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1202 보석 도둑
            털 수 있는 보석 N개
            보석은 무게 M, 가격 V
            가방 K개, 최대 무게 C - 가방에는 1개의 보석만 넣을 수 있다
            훔칠 수 있는 보석의 최대 가격을 구해라

            ** 필요 변수 **
            int n, k 입력값, 보석의 개수, 가방의 개수
            PriorityQueue<int, int> queue : 현재 가방에 담을 수 있는 보석들의 가격
 
            ** 아이디어 ** 
            가방을 오름차순으로 정렬
            가방에 넣을 수 있는 모든 보석을 큐에 넣고, 그 중 가장 비싼 값 더하기

            ** 시간 복잡도 **
            O((N+K)log N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = input[0];
            int k = input[1];

            (int m, int v)[] gems = new (int m, int v)[n];
            for(int i = 0; i < n; i++)
            {
                int[] gem = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                gems[i] = (gem[0], gem[1]);
            }

            int[] c = new int[k];
            for(int i = 0; i < k; i++)
            {
                c[i] = int.Parse(reader.ReadLine());
            }

            Array.Sort(gems, (a, b) => a.m.CompareTo(b.m));
            Array.Sort(c);
        
            long total = 0;

            var queue = new PriorityQueue<int, int>(); 
            int gemIdx = 0;

            for(int i = 0; i < k; i++)
            {
                while(gemIdx < n && gems[gemIdx].m <= c[i])
                {
                    queue.Enqueue(gems[gemIdx].v, -gems[gemIdx].v);
                    gemIdx++;
                }

                if(queue.Count > 0)
                {
                    total += queue.Dequeue();
                }
            }

            writer.WriteLine(total);
            writer.Flush();
        }
    }
}