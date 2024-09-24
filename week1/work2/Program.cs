using System;

class PrimeFactorization
{
    static void Main()
    {
        Console.WriteLine("请输入一个正整数：");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number <= 0)
        {
            Console.WriteLine("输入的数字必须是正整数。");
            return;
        }

        Console.WriteLine($"数字 {number} 的素数因子有：");
        for (int i = 2; i <= number; i++)
        {
            while (number % i == 0)
            {
                Console.WriteLine(i);
                number /= i;
            }
        }
    }
}