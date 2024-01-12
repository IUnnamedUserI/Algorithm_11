using System;

class LongestIncreasingSubsequence
{
    static void Main()
    {
        Console.WriteLine("Введите количество элементов: ");
        Console.Write(">>> ");
        int N = int.Parse(Console.ReadLine());
        int[] nums = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write($"[{i}] ");
            nums[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine($"Длина наибольшей возрастающей подпоследовательности: {FindLength(nums)}");

        Console.WriteLine("Для завершения работы программы нажмите любую клавишу...");
        Console.ReadKey();
    }

    static int FindLength(int[] nums)
    {
        int n = nums.Length;
        if (n == 0) return 0;

        int[] dp = new int[n];
        dp[0] = 1;
        int maxLength = 1;

        for (int i = 1; i < n; i++)
        {
            dp[i] = 1;

            for (int j = 0; j < i; j++)
                if (nums[i] > nums[j] && dp[i] < dp[j] + 1) dp[i] = dp[j] + 1;

            maxLength = Math.Max(maxLength, dp[i]);
        }
        return maxLength;
    }
}