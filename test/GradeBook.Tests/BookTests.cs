using System;
using Xunit;

namespace GradeBook.Tests //.Tests implies being inside GradeBook namespace, therefore no using statement is needed
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // arrange section, put together test data
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act, invoke method to perform actual result
            var result = book.GetStats();

            // assert, test
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);

        }
    }
}
