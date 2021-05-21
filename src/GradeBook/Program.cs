using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {10.2, 33.4, 25.2222, 11.1};
            var result = 0.0; 
            foreach(var number in numbers)
            {
                result += number;
            }

            Console.WriteLine(result);

            if(args.Length > 0)
            {
                Console.WriteLine($"Total Score:");
            }
            else
            {
                Console.WriteLine("Hello, World");
            }
            
        }
    }
}
