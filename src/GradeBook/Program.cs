using System;
using System.Collections.Generic; //List's namespace

namespace GradeBook //keep your classes in their own namespace, avoid conflicts
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("My Gradebook");
            //do while loop to ask for book name?
            book.GradeAdded += OnGradeAdded; // things listening/subscribed to event, can only use += or -=

            EnterGrades(book);

            var stats = book.GetStats();
            book.Name = "";

            Console.WriteLine($"For the book named {book.Name}:");
            Console.WriteLine($"Avg: {stats.Average:N1} | High Grade: {stats.High} | Low Grade: {stats.Low}");
            Console.WriteLine($"The average letter grade is: {stats.Letter}");
            //refactoring, unit test forces improvement in code


        }

        private static void EnterGrades(Book book) //lightbulb to extract method
        {
            while (true)
            {
                Console.WriteLine("Enter grade or 'q' to quit.");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); //catching exception
                }


            };
        }

        static void OnGradeAdded(object sender, EventArgs e) //reacting to event
        {
            Console.WriteLine("A grade was added.");
        }
    }
}
