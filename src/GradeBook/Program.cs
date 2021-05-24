using System;
using System.Collections.Generic; //List's namespace

namespace GradeBook //keep your classes in their own namespace, avoid conflicts
{
    
    class Program
    {
        static void Main(string[] args)
        {            
            var book = new Book("Bookname");
            book.AddGrade(33.3);
            book.AddGrade(44.3);

            var grades = new List<double>() {1.2, 2.2, 1.1, 1.1};
            grades.Add(1.1);

            var result = 0.0; 
            var highGrade = double.MinValue; //lowest possible double value
            var lowGrade = double.MaxValue; //largest possible double value
            foreach(var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }
            
            result /= grades.Count;
            Console.WriteLine($"Avg: {result:N1} | High Grade: {highGrade} | Low Grade: {lowGrade}");
            
        }
    }
}
