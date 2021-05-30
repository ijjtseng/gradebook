using System;
using System.Collections.Generic;

namespace GradeBook //make sure name matches Program.cs namepsace
{
   public class Book //default internal, not public. just need public for unit testing.
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

        public Stats GetStats() //needs to return an object, classes define object, GetStats carries values to destination
        {
            var result = new Stats();
            result.Average = 0.0;
            result.High = double.MinValue; //lowest possible double value
            result.Low = double.MaxValue; //largest possible double value

            foreach(var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;
        private string name;
        
    }
}