using System;
using Xunit;

namespace GradeBook.Tests //.Tests implies being inside GradeBook namespace, therefore no using statement is needed
{
    public class TypeTests
    {
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
