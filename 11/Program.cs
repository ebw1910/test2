using System;
using System.Threading;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в чат!");
            Bot bot = new Bot();
            while (bot.flag)
            {
                bot.Read();
                bot.StartMainLoopAsync();
            }
        }
    }
}
