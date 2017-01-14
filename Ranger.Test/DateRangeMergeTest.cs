using System;
using Xunit;

namespace Ranger.Test
{
    public class DateRangeMergeTest
    {
        [Fact]
        public void ItShouldMergeTwoOverlappingPeriods()
        {
            // Given
            var startDateA = new DateTime(2017, 1, 1);
            var endDateA = new DateTime(2017, 1, 10);

            var dateRangeA = new DateRange(startDateA, endDateA);

            var startDateB = new DateTime(2017, 1, 5);
            var endDateB = new DateTime(2017, 1, 15);
            var dateRangeB = new DateRange(startDateB, endDateB);

            // When
            var result = dateRangeA.Merge(dateRangeB);

            // Then
            Assert.True(result.StartDate == startDateA);
            Assert.True(result.EndDate == endDateB);
        }
    }
}
