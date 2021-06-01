using System;
using System.Collections.Generic;

namespace GradeBook //make sure name matches Program.cs namepsace
{
   public class Book //default internal, not public. just need public for unit testing.
    {
        
        public  Book(string name) //creating explicit constructor, must have same name as class
        {
            grades = new List<double>();
            Name = name;
        }

        
        public void AddGrade(double grade) //creating method
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid Value");
            }
            
        }

        public Stats GetStats() //needs to return an object, classes define object, GetStats carries values to destination
        {
            var result = new Stats();
            result.Average = 0.0;
            result.High = double.MinValue; //lowest possible double value
            result.Low = double.MaxValue; //largest possible double value

            //for loop
            for(var index = 0; index < grades.Count; index++) 
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
            };


            //do while loop will execute at least once, while loop executes when condition is met
            // var index = 0;
            // while(index < grades.Count) 
            // {
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];
            //     index++;
            // };

            // foreach(var grade in grades)
            // {
            //     result.High = Math.Max(grade, result.High);
            //     result.Low = Math.Min(grade, result.Low);
            //     result.Average += grade;
            // }

            result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;
        public string Name;
        
    }
}