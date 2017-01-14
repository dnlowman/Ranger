using System;
using Xunit;

namespace Ranger.Test
{
    public class DateRangeIntersectTest
    {
        [Fact]
        public void ItShouldReturnTheStartOfTheOtherRangeAndTheEndOfTheCurrentRange()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 20);
            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 10);
            var endDateB = new DateTime(2017, 1, 25);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Intersect(dateRangeB);

            // Then
            Assert.True(result.StartDate == startDateB);
            Assert.True(result.EndDate == endDateA);
        }

        [Fact]
        public void ItShouldReturnTheStartOfTheCurrentAndTheEndOfTheOther()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 10);
            var endDateA = new DateTime(2017, 1, 20);
            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 1);
            var endDateB = new DateTime(2017, 1, 15);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Intersect(dateRangeB);

            // Then
            Assert.True(result.StartDate == startDateA);
            Assert.True(result.EndDate == endDateB);
        }

        [Fact]
        public void ItShouldReturnTheStartOfTheCurrentAndTheEndOfTheCurrent()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 10);
            var endDateA = new DateTime(2017, 1, 20);
            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 1);
            var endDateB = new DateTime(2017, 1, 25);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Intersect(dateRangeB);

            // Then
            Assert.True(result.StartDate == startDateA);
            Assert.True(result.EndDate == endDateA);
        }

        [Fact]
        public void ItShouldReturnTheStartOfTheOtherAndTheEndOfTheOther()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 10);
            var endDateA = new DateTime(2017, 1, 20);
            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 11);
            var endDateB = new DateTime(2017, 1, 19);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Intersect(dateRangeB);

            // Then
            Assert.True(result.StartDate == startDateB);
            Assert.True(result.EndDate == endDateB);
        }
    }
}
