using System;
using infrastructure.Models;
using Xunit;

namespace infrastructure.Tests.ModelTests
{
    public class SpaceEventTests
    {
        [Fact]
        public void DateParts()
        {
            // Arrange
            var Now = DateTime.Now;
            var SE = new SpaceEvent() { Date = Now };

            // Assert
            Assert.Equal(Now.Year, SE.Year);
            Assert.Equal(Now.Month, SE.Month);
            Assert.Equal(Now.Day, SE.Day);
        }

        [Fact]
        public void ConvenienceDate()
        {
            // Arrange
            var TheDate = new DateTime(1977, 5, 19);
            var Now = DateTime.Now;
            var SE = new SpaceEvent() { Date = TheDate };
            
            // Act
            var ReturnedDate = SE.ConvenienceDate;
            
            // Assert
            Assert.Equal(Now.Year, ReturnedDate.Year);
            Assert.Equal(TheDate.Month, ReturnedDate.Month);
            Assert.Equal(TheDate.Day, ReturnedDate.Day);
        }
    }
}