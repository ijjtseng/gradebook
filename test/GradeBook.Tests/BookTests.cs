using System;
using Xunit;

namespace GradeBook.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // arrange section, put together test data
            var x = 5;
            var y = 2;
            var expected = 7;

            // act, invoke method to perform actual result
            var actual = x + y;

            // assert, test
            Assert.Equal(expected, actual);
        }
    }
}
