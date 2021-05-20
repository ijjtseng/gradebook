using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 333.33;
            double y = 11.1 + x;

            if(args.Length > 0)
            {
                Console.WriteLine($"Total Score: {y}");
            }
            else
            {
                Console.WriteLine("Hello, World");
            }
            
        }
    }
}
