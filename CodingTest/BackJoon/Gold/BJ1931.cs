namespace BackJoon
{
    class BackJoon1931 : IBackJoon
    {
        /*
            ** 문제 요약 **
            1931 회의실 배정
            1개의 회의실, N 개의 회의
            각 회의가 겹치지 않게 할 수 있는 회의의 최대 개수

            ** 필요 변수 **
            int n 입력값 회의의 개수
            (int, int)[] meetings 회의들의 시작, 종료 시간 배열
            int curTime 현재 시각
            int cnt 회의 진행한 횟수
 
            ** 아이디어 ** 
            그리디 알고리즘, 정렬
            회의를 (int, int)[] 자료구조로 저장하여
            끝나는 시간이 빠르고, 그 와중에 시작 시간이 빠른 순으로 정렬
            curTime <= 회의 시작 시간:
                curTime = 회의 끝나는 시간
                회의 진행한 횟수 증가
            전체 배열을 순회하며 확인

            ** 시간 복잡도 **
            O(N logN)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            int n = int.Parse(reader.ReadLine());

            (int start, int end)[] meetings = new (int start, int end)[n];
            for(int i = 0; i < n; i++)
            {
                int[] meeting = Array.ConvertAll(reader.ReadLine().Split(' '), int.Parse);
                meetings[i] = (meeting[0], meeting[1]);
            } 

            meetings = meetings
                .OrderBy(m => m.end)
                .ThenBy(m => m.start)
                .ToArray();

            int curTime = 0;
            int cnt = 0;

            for(int i = 0; i < n; i++)
            {
                var meeting = meetings[i];

                if(curTime <= meeting.start)
                {
                    curTime = meeting.end;
                    cnt++;
                }
            }
            
            writer.WriteLine(cnt);
            writer.Flush();
        }
    }
}