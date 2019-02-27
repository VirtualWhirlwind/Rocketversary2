using System;

namespace infrastructure.Support
{
    public static class Utilities
    {
        public static int DayIndex(DateTime input)
        {
            return (new DateTime(2020, input.Month, input.Day)).DayOfYear;
        }
    }
}