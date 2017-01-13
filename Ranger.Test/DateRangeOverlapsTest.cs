using System;
using Xunit;

namespace Ranger.Test
{
    public class DateRangeOverlapsTest
    {
        [Fact]
        public void ItShouldReturnTrueWhenOnlyTheStartDateOverlapsWithAnotherPeriod()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 10);

            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2016, 12, 31);
            var endDateB = new DateTime(2017, 1, 5);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Overlaps(dateRangeB);

            // Then
            Assert.True(result);
        }

        [Fact]
        public void ItShouldReturnTrueWhenOnlyTheEndDateOverlapsWithAnotherPeriod()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 10);

            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 5);
            var endDateB = new DateTime(2017, 1, 12);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Overlaps(dateRangeB);

            // Then
            Assert.True(result);
        }

        [Fact]
        public void ItShouldReturnTrueWhenAnotherPeriodStartsAndEndsOnTheSameDates()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 10);

            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 1);
            var endDateB = new DateTime(2017, 1, 10);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Overlaps(dateRangeB);

            // Then
            Assert.True(result);
        }

        [Fact]
        public void ItShouldReturnTrueWhenAnotherPeriodOverlapsInBetweenTheDates()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 10);

            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 2);
            var endDateB = new DateTime(2017, 1, 9);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Overlaps(dateRangeB);

            // Then
            Assert.True(result);
        }

        [Fact]
        public void ItShouldReturnFalseWhenThePeriodDoesNotOverlapWithAnotherDateRange()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 10);

            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2018, 1, 1);
            var endDateB = new DateTime(2018, 1, 10);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Overlaps(dateRangeB);

            // Then
            Assert.False(result);
        }
    }
}
