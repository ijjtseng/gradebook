using System;
using Xunit;

namespace GradeBook.Tests //.Tests implies being inside GradeBook namespace, therefore no using statement is needed
{
    //class is reference type, struct --> value, highlight+F12 to check if reference or value type
    public class TypeTests 
    {
        [Fact]
        public void GradeMustBeZeroToOneHundred()
        {
            var book1 = GetBook("Book 1");
            book1.AddGrade(5);
            book1.AddGrade(-5);
            book1.AddGrade(105);
            var stats = book1.GetStats();

            Assert.Equal(5, stats.Low);
            Assert.Equal('F', stats.Letter);
        }
        
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            //strings are immutable
            string name = "Name";
            var upper = MakeUppercase(name);

            Assert.Equal("Name", name);
            Assert.Equal("NAME", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper(); //w/o return, ToUpper returns a copy, not changing actual string
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt(); // value is copied into variable
            SetInt(out x);
            Assert.Equal(42, x);
        }

        private void SetInt(out int y)
        {
            y = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCouldPassByRef() // ref!!
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1, "New Name"); // ref OR out
            
            Assert.Equal("New Name", book1.Name);

        }
        // out parameter assumes incoming reference has not yet been initialized, out paramter must be assigned to smth
        private void GetBookSetNameByRef(ref Book book, string name) // ref OR out
        {
            book = new Book(name); //NECESSARY output because out
        }
        
        [Fact]
        public void CSharpIsPassByValue() //Trying to pass by reference here and failed. when passing var to method, method won't change value of original var. 
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(Book book, string name) //book value memory location is diff than var book1
        {
            book = new Book(name); //constructs new book obj
            book.Name = name;
        }
        
        [Fact]
        public void CanSetNameFromReference() //Csharp is pass by value!
        {
            var book1 = GetBook("Book 1");
            //var book2 = book1;
            SetName(book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
            //Assert.Equal("New Name", book2.Name);

        }

        private void SetName(Book book, string name)
        {
            book.Name = name; 
        }

        [Fact]
        public void GetBookReturnsDiffObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            //Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObj()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            
            Assert.Same(book1, book2);
            // Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private Book GetBook(string name) //private is default, can omit "private" from this line
        {
            return new Book(name);
        }
    }
}
