using System;
using Xunit;

namespace Ranger.Test
{
    public class DateRangeEqualsTest
    {
        [Fact]
        public void ItShouldReturnTrueWhenADateRangeIsEqualToAnotherDateRange()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 10);

            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 1);
            var endDateB = new DateTime(2017, 1, 10);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Equals(dateRangeB);

            // Then
            Assert.True(result);
        }

        [Fact]
        public void ItShouldReturnFalseWhenADateRangeIsNotEqualToAnotherDateRange()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 10);

            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2016, 12, 31);
            var endDateB = new DateTime(2017, 1, 5);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Equals(dateRangeB);

            // Then
            Assert.False(result);
        }
    }
}
