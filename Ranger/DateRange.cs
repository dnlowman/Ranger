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

        public DateRange Intersect(DateRange other)
        {
            if (StartDate <= other.StartDate &&
                other.StartDate < EndDate &&
                EndDate < other.EndDate)
                return new DateRange(other.StartDate, EndDate);

            if (other.StartDate < StartDate &&
                other.EndDate < EndDate)
                return new DateRange(StartDate, other.EndDate);

            if (other.StartDate < StartDate &&
                other.EndDate > EndDate)
                return new DateRange(StartDate, EndDate);

            if (other.StartDate >= StartDate &&
               other.EndDate <= EndDate)
                return new DateRange(other.StartDate, other.EndDate);

            return null;
        }

        public bool Contains(DateTime dateTime)
        {
            return (StartDate <= dateTime && dateTime <= EndDate);
        }

        public static bool operator ==(DateRange a, DateRange b)
        {
            return a.StartDate == b.StartDate && a.EndDate == b.EndDate;
        }

        public static bool operator !=(DateRange a, DateRange b)
        {
            return a.StartDate != b.StartDate && a.EndDate != b.EndDate;
        }

        public override bool Equals(object obj)
        {
            return this == obj as DateRange;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
