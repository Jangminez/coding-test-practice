namespace BackJoon
{
    class BackJoon1541 : IBackJoon
    {
        /*
            ** 문제 요약 ** 
            1541 잃어버린 괄호
            수식에 괄호를 쳐서 수식의 최솟값을 구해라
 
            ** 아이디어 ** 
            그리디 알고리즘
            '-' 뒤에 부분을 크게 만들어야함
            수식을 '-' 기준으로 분리하고, 분리된 string 안에 '+'가 있다면 모두 더하기 후
            합의 최솟값 구하기

            ** 시간 복잡도 **
            O(N)
        */

        static StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        public void Solution()
        {
            string[] input = reader.ReadLine().Split('-');

            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int num = 0;
                if(input[i].Contains('+'))
                {
                    string[] nums = input[i].Split('+');

                    for(int j = 0; j < nums.Length; j++)
                    {
                        num += int.Parse(nums[j]);
                    }
                }
                else
                {
                    num = int.Parse(input[i]);
                }

                sum = i == 0 ? sum + num : sum - num;
            }

            writer.WriteLine(sum);
            writer.Flush();
        }
    }
}