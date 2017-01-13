using System;
using Xunit;

namespace Ranger.Test
{
    public class DateRangeConstructorTest
    {
        [Fact]
        public void TheConstructorShouldAcceptAStartAndEndDateTime()
        {
            // Given
            var startDate = DateTime.Now;
            var endDate = DateTime.Now;

            // When
            var dateRange = new DateRange(startDate, endDate);

            // Then
            Assert.Equal(startDate, dateRange.StartDate);
            Assert.Equal(endDate, dateRange.EndDate);
        }

        [Fact]
        public void TheConstructorShouldAcceptTheStartAndEndDateAsNull()
        {
            // Given
            DateTime? startDate = null;
            DateTime? endDate = null;

            // When
            var dateRange = new DateRange(startDate, endDate);

            // Then
            Assert.Equal(startDate, dateRange.StartDate);
            Assert.Equal(endDate, dateRange.EndDate);
        }
    }
}
