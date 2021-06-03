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

        public void AddGrade(char letter) //method overloading, same name but diff signature
        {
            
            //switch statement
            switch(letter)
            {
                case 'A': 
                    AddGrade(90); 
                    break;
                case 'B':
                    AddGrade(80); 
                    break;
                case 'C':
                    AddGrade(70); 
                    break;
                case 'D':
                    AddGrade(60); 
                    break;
                default:
                    AddGrade(0);
                    break;
            }   
        }

        
        public void AddGrade(double grade) //creating method
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}."); //throwing exceptions
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
                if (grades[index] == 44.4) //if condition met, break statement
                {
                    break; //jump to end bracket OR "continue" loop but jump for this index (OR in very very rare instannce, "goto")
                }
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


            //C# v7, pattern matching switch statement
            switch(result.Average)
            {
                case var x when x >= 90.0:
                    result.Letter = 'A';
                    break;

                case var x when x >= 80.0:
                    result.Letter = 'B';
                    break;

                case var x when x >= 70.0:
                    result.Letter = 'C';
                    break;

                case var x when x >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;

            }

            return result;
        }

        //fields
        private List<double> grades;
        //public string Name;

        //property - encapsulate state and data
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }


        private string name;

        

        

        
    }
}