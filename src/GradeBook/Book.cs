using System.Collections.Generic;

namespace GradeBook //make sure name matches Program.cs namepsace
{
   class Book
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
        private List<double> grades;
        private string name;
        
    }
}