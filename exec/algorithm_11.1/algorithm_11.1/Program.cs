using System;

class Program
{
    static void Main()
    {
        Console.WriteLine($"Введите значение N");
        Console.Write(">>> ");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine($"\nФибоначчи({N}) разными функциями:");
        Console.WriteLine($"Рекурсивная функция с верхним уровнем({N}) = {Fibonacci(N, "TD")}");
        Console.WriteLine($"Итеративная функция с нижним уровнем({N}) = {Fibonacci(N, "BU")}");
        Console.WriteLine($"Улучшенная итеративная функция с нижним уровнем({N}) = {Fibonacci(N, "Improved")}");
        Console.WriteLine("\nДля завершения работы программы нажмите любую клавишу...");
        Console.ReadKey();
    }

    static int Fibonacci(int n, string func = "TD")
    {
        int[] f = new int[n + 1];

        int FibTopDown(int k)
        {
            if (k <= 1) f[k] = k;
            else f[k] = FibTopDown(k - 1) + FibTopDown(k - 2);
            return f[k];
        }

        int FibBottomUp(int k)
        {
            int[] fib = new int[k + 1];
            fib[0] = 0; fib[1] = 1;
            for (int i = 2; i <= k; i++) fib[i] = fib[i - 1] + fib[i - 2];
            return fib[k];
        }

        int FibBottomUpImproved(int k)
        {
            if (k <= 1) return k;

            int prev = 0, curr = 1;
            for (int i = 1; i < k; i++)
            {
                int temp = curr;
                curr = prev + curr;
                prev = temp;
            }
            return curr;
        }

        switch (func)
        {
            case "TD": f = new int[n + 1]; return FibTopDown(n);
            case "BU": return FibBottomUp(n);
            case "Improved": return FibBottomUpImproved(n);
            default:
                Console.WriteLine($"[Ошибка] Неизвестная функция {func}");
                Environment.Exit(1);
                return 0;
        }
    }
}