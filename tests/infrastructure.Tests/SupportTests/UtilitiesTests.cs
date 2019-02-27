using System;
using infrastructure.Support;
using Xunit;

namespace infrastructure.Tests.SupportTests
{
    public class UtilitiesTests
    {
        [Fact]
        public void DayIndex()
        {
            // Arrange
            var UseDate0 = new DateTime(2019, 1, 1);
            var Result0 = Utilities.DayIndex(UseDate0);
            var UseDate1 = new DateTime(2019, 02, 26);
            var Result1 = Utilities.DayIndex(UseDate1);
            var UseDate2 = new DateTime(2019, 12, 31);
            var Result2 = Utilities.DayIndex(UseDate2);

            // Assert
            Assert.Equal(1, Result0);
            Assert.Equal(57, Result1);
            Assert.Equal(366, Result2);
        }
    }
}