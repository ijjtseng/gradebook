using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook //make sure name matches Program.cs namepsace
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    //normally make separate cs file, one file per TYPE
    //events take two paramters (object and EventArgs) see line above

    public interface IBook //what members are avail for anything that implements this interface
    {
        void AddGrade(double grade);
        Stats GetStats();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObj, IBook //any class with BookBase take AddGrade Method
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded; // virtual, abstract, override
        public abstract void AddGrade(double grade);
        public abstract Stats GetStats();
    }


    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt")) //for files because IDisposable
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }

            //writer.Dispose(); 
            // or writer.Close();
        }

        public override Stats GetStats()
        {
            var result = new Stats();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;

        }
    }

    public class InMemoryBook : Book //meaning Book is a NamedObj
                                     //public v private -- default internal, not public. just need public for unit testing.
    {

        public InMemoryBook(string name) : base(name) //creating explicit constructor, must have same name as class
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter) //method overloading, same name but diff signature
        {

            //switch statement
            switch (letter)
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


        public override void AddGrade(double grade) //creating method
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);

                // event delegate ... call software to show a grade has been added
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}."); //throwing exceptions
            }

        }

        public override event GradeAddedDelegate GradeAdded; //field

        public override Stats GetStats() //needs to return an object, classes define object, GetStats carries values to destination
        {
            var result = new Stats();

            //for loop
            for (var index = 0; index < grades.Count; index++)
            {
                if (grades[index] == 44.4) //if condition met, break statement
                {
                    break; //jump to end bracket OR "continue" loop but jump for this index (OR in very very rare instannce, "goto")
                }

                result.Add(grades[index]);
                //result.Average += grades[index];
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

            //result.Average /= grades.Count;


            // //C# v7, pattern matching switch statement
            // switch(result.Average)
            // {
            //     case var x when x >= 90.0:
            //         result.Letter = 'A';
            //         break;

            //     case var x when x >= 80.0:
            //         result.Letter = 'B';
            //         break;

            //     case var x when x >= 70.0:
            //         result.Letter = 'C';
            //         break;

            //     case var x when x >= 60.0:
            //         result.Letter = 'D';
            //         break;

            //     default:
            //         result.Letter = 'F';
            //         break;

            // }

            return result;
        }

        //fields
        private List<double> grades;
        //public string Name;



        // private string name;

        //readonly string category = "Science"; //readonly field, assigned in constructor
        //public const string CATEGORY = "Science"; //const field, referenced by Book.CATEGORY and not book.CATEGORY







    }
}