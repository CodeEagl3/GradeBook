// using GradeBook;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
            // arrange        
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            // act
            var stats = book.GetStatistics();

            // assert
            Assert.Equal(85.7, stats.Average);
            Assert.Equal(77.5, stats.Low);
            Assert.Equal(90.5, stats.High);
            Assert.Equal('B', stats.Letter);
        }
    }
}
