using System;

class KnapsackProblem
{
    static void Main()
    {
        // Входные данные
        int[] values = { 60, 100, 120 }; // Фиксированные значения объёма
        int[] weights = { 10, 20, 30 }; // Фиксированные значения веса
        Console.WriteLine("Введите значение вместительности:");
        Console.Write(">>> ");
        int capacity = int.Parse(Console.ReadLine()); // Вводимое значение вместительности

        Console.WriteLine("Максимальная стоимость рюкзака (неограниченное количество предметов): " +
            $"{KnapsackUnlimited(values, weights, capacity)}");
        Console.WriteLine("Максимальная стоимость рюкзака (ограниченное количество предметов): " +
            $"{KnapsackLimited(values, weights, capacity)}");

        Console.WriteLine("\nДля завершения работы программы нажмите любую клавишу...");
        Console.ReadKey();
    }

    static int KnapsackUnlimited(int[] values, int[] weights, int capacity)
    {
        int n = values.Length;
        int[] dp = new int[capacity + 1];

        for (int i = 1; i <= capacity; i++)
            for (int j = 0; j < n; j++)
                if (weights[j] <= i) dp[i] = Math.Max(dp[i], dp[i - weights[j]] + values[j]);

        return dp[capacity];
    }

    static int KnapsackLimited(int[] values, int[] weights, int capacity)
    {
        int n = values.Length;
        int[,] dp = new int[n + 1, capacity + 1];

        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= capacity; j++)
                if (weights[i - 1] <= j) dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - weights[i - 1]] + values[i - 1]);
                else dp[i, j] = dp[i - 1, j];

        return dp[n, capacity];
    }
}