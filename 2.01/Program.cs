using System;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            {

                int x;
                for (int i = 0; ;)
                {
                    Console.WriteLine("Введите трехзначное чило");
                    while (!int.TryParse(Console.ReadLine(), out x))
                        Console.Write("Необходимо ввести целое трёхзначное число! \nВведите трехзначное число: ");
                    if (x > 999 || x <= 99)
                    {

                        Console.WriteLine("Число должно быть тёхзначным!");
                        continue;
                    }
                    else

                        Console.WriteLine("Сумма чисел в переменной: {0}", IterFunc(x));
                    break;
                }
            }

            static int IterFunc(int n)
            {
                if (n < 10) return n;
                else return ((n % 10) + IterFunc(n / 10));
            }

        }
    }
}
