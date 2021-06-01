using System;
using System.Collections.Generic; //List's namespace

namespace GradeBook //keep your classes in their own namespace, avoid conflicts
{
    
    class Program
    {
        static void Main(string[] args)
        {            
            var book = new Book("My Gradebook");
             
            while(true)
            {
                Console.WriteLine("Enter grade or 'q' to quit.");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                var grade = double.Parse(input);
                book.AddGrade(grade);

            };

            var stats = book.GetStats();

            Console.WriteLine($"Avg: {stats.Average:N1} | High Grade: {stats.High} | Low Grade: {stats.Low}");
            Console.WriteLine($"The average letter grade is: {stats.Letter}");
            //refactoring, unit test forces improvement in code
            
            
        }
    }
}
