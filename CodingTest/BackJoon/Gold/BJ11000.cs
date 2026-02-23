namespace BackJoon
{
    class BackJoon11000 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            11000 강의실 배정
            Sᵢ 에 시작해서 Tᵢ에 끝나는 N개의 수업
            최소의 강의실을 사용해서 모든 수업을 가능하게 하는 방법
            수업이 끝난 직후에 다음 수업 시작 가능

            ** 아이디어 ** 
            그리디, 우선순위 큐
            강의들을 입력받아 강의 시작이 빠른순으로 정렬한다.
            정렬된 강의를 순회하며 우선순위 큐를 활용
            강의의 끝나는 시점을 우선순위 큐에 넣고, 현재 강의의 시작시간과 비교하여 처리

            ** 시간 복잡도 **
            O(NlogN)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());

            (int s, int t)[] classes = new (int s, int t)[n];
            for (int i = 0; i < n; i++)
            {
                int[] st = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                classes[i] = (st[0], st[1]);
            }

            Array.Sort(classes, (a, b) => a.s.CompareTo(b.s));

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < n; i++)
            {
                var cur = classes[i];

                if(pq.Count > 0 && pq.Peek() <= cur.s)
                {
                    pq.Dequeue();
                }

                pq.Enqueue(cur.t, cur.t);
            }

            writer.WriteLine(pq.Count);
            writer.Flush();
        }
    }
}