using System;
using System.Linq;
using Xunit;

namespace Ranger.Test
{
    public class DateRangeDivideTest
    {
        [Fact]
        public void ItShouldDivideAPeriodIntoTwo()
        {
            // Given
            var startDate = new DateTime(2017, 1, 1);
            var endDate = new DateTime(2017, 1, 10);

            var dateRange = new DateRange(startDate, endDate);

            var division = new DateTime(2017, 1, 5);

            // When
            var result = dateRange.Divide(division)
                                  .ToList();

            // Then
            Assert.True(result[0].StartDate == startDate);
            Assert.True(result[0].EndDate == division.Subtract(new TimeSpan(0, 0, 1)));

            Assert.True(result[1].StartDate == division);
            Assert.True(result[1].EndDate == endDate);
        }
    }
}
