using System;

namespace Ranger
{
    public class DateRange
    {
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public DateRange(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool Overlaps(DateRange dateRange)
        {
            return StartDate <= dateRange.EndDate && dateRange.StartDate <= EndDate;
        }

        public bool Contains(DateTime dateTime)
        {
            return (StartDate <= dateTime && dateTime <= EndDate);
        }
    }
}
