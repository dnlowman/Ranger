using System;
using Xunit;

namespace Ranger.Test
{
    public class DateRangeContainsTest
    {
        [Fact]
        public void ItShouldReturnTrueWhenThePeriodContainsADateTime()
        {
            // Given
            var startDate = new DateTime(2017, 1, 1);
            var endDate = new DateTime(2017, 1, 10);
            var dateRange = new DateRange(startDate, endDate);

            var date = new DateTime(2017, 1, 5);

            // When
            var result = dateRange.Contains(date);

            // Then
            Assert.True(result);
        }

        [Fact]
        public void ItShouldReturnFalseWhenThePeriodDoesNotContainADateTime()
        {
            // Given
            var startDate = new DateTime(2017, 1, 1);
            var endDate = new DateTime(2017, 1, 10);
            var dateRange = new DateRange(startDate, endDate);

            var date = new DateTime(2019, 1, 5);

            // When
            var result = dateRange.Contains(date);

            // Then
            Assert.False(result);
        }
    }
}
