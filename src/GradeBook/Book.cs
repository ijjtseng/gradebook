using System;
using System.Collections.Generic;

namespace GradeBook //make sure name matches Program.cs namepsace
{
   public class Book //default internal, not public
    {
        
        public  Book(string name) //creating explicit constructor, must have same name as class
        {
            grades = new List<double>();
            this.name = name;
        }

        
        public void AddGrade(double grade) //creating method
        {
            grades.Add(grade);
        }

        public void ShowStats()
        {
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

        private List<double> grades;
        private string name;
        
    }
}