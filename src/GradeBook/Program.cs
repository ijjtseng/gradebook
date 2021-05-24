using System;
using System.Collections.Generic; //List's namespace

namespace GradeBook //keep your classes in their own namespace, avoid conflicts
{
    
    class Program
    {
        static void Main(string[] args)
        {            
            var book = new Book("My Gradebook");
            book.AddGrade(33.3);
            book.AddGrade(44.3);
            book.AddGrade(74.3);
            book.ShowStats();

            
            
        }
    }
}
