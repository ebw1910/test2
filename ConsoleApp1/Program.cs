using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ladder myFirstladder = new ladder();
            myFirstladder.Height = 10;
            myFirstladder.Width = 20;
            myFirstladder.Lengthwise = myFirstladder.Width;
            Console.WriteLine("Высота: " + myFirstladder.Height);
            Console.WriteLine("Ширина: " + myFirstladder.Width);
            Console.WriteLine("Глубина: " + myFirstladder.Lengthwise);

            Console.ReadLine();
           
        }
    }
    class ladder
    {
        int width;
        int height;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Lengthwise { get; set; }
    }
}
