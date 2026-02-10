namespace BackJoon
{
    class BackJoon1717 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1717 집합의 표현
            n + 1개의 집합, 합집합 연산과 두 원소가 같은 집합에 포합되어 있는지를 확인하는 연산 수행

            ** 아이디어 ** 
            Union-Find
            각 원소의 부모를 저장하는 parent 배열
            Find : 재귀적으로 부모 노드 찾기
            Union : 두 원소의 부모가 다르다면 한쪽을 다른 쪽에 합침
            
            ** 시간 복잡도 **
            O(M * α(N))
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        static int[] parent;

        public void Solution()
        {
            int[] nm = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
            int n = nm[0];
            int m = nm[1];

            parent = new int[n + 1];
            for(int i = 0; i < n + 1; i++) parent[i] = i;

            for(int i = 0; i < m; i++)
            {
                int[] input = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                int type = input[0];

                if(type == 0)
                {
                    Union(input[1], input[2]);
                }
                else
                {
                    int rootA = Find(input[1]);
                    int rootB = Find(input[2]);

                    if(rootA == rootB) writer.WriteLine("YES");
                    else writer.WriteLine("NO");
                }
            }
            writer.Flush();
        }

        private int Find(int x)
        {
            if(parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }

        private void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if(rootA != rootB)
            {
                parent[rootB] = rootA;
            }
        }
    }
}