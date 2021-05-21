using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {            
            var grades = new List<double>() {10.2, 33.4, 25.2222, 11.1};
            grades.Add(22.2);
            var numofGrades = grades.Count;

            var sum = 0.0; 
            foreach(var number in grades)
            {
                sum += number;
            }
            
            var avg = sum / numofGrades;

            Console.WriteLine($"Total: {sum:N3}, Avg: {avg:N1}");

            if(args.Length > 0)
            {
                Console.WriteLine($"Total Score: {sum}");
            }
            else
            {
                Console.WriteLine("Hello, World");
            }
            
        }
    }
}
