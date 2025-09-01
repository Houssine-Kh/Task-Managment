using System;

namespace Domain.ValueObjects
{
    public class DueDate
    {
        public DateTime ValueUtc { get; private set; }

        private DueDate(DateTime valueUtc)
        {
            ValueUtc = valueUtc;
        }

        public static DueDate FromUtc(DateTime valueUtc)
        {
            if (valueUtc <= DateTime.UtcNow)
                throw new ArgumentException("Due date must be in the future.");
            return new DueDate(valueUtc);
        }
    }
}
