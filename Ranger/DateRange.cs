using System;
using System.Collections;
using System.Collections.Generic;

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

        public DateRange Merge(DateRange other)
        {
            if (!Overlaps(other))
                return new DateRange(StartDate, EndDate);

            var startDate = StartDate <= other.StartDate ? StartDate : other.StartDate;
            var endDate = EndDate <= other.EndDate ? other.EndDate : EndDate;

            return new DateRange(startDate, endDate);
        }

        public IEnumerable<DateRange> Divide(DateTime division)
        {
            if (!Contains(division))
                return new List<DateRange>
                {
                    new DateRange(StartDate, EndDate)
                };

            return new List<DateRange>
            {
                new DateRange(StartDate, division.Subtract(new TimeSpan(0, 0, 1))),
                new DateRange(division, EndDate)
            };
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
