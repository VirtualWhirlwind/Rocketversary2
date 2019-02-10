using System;
using System.Collections.Generic;

namespace core.Interfaces
{
    public interface ISpaceEvent
    {
        string _id { get; set; }
        string Name { get; set; }
        string Subtitle { get; set; }
        string Country { get; set; }
        DateTime Date { get; set; }
        string URL { get; set; }
        string Description { get; set; }

        int Year { get; }
        int Month { get; }
        int Day { get; }
        string GenericDate { get; }

        DateTime ConvenienceDate { get; }
    }
    public class SpaceEventComparer : IComparer<ISpaceEvent>
    {
        public int Compare(ISpaceEvent one, ISpaceEvent two)
        {
            if (one == null)
            {
                if (two == null) { return 0; }
                else { return -1; }
            }
            else
            {
                if (two == null) { return 1; }
                else
                {
                    var Result = one.Date.CompareTo(two.Date);

                    if (Result == 0)
                    {
                        Result = one.Name.CompareTo(two.Name);
                    }

                    return Result;
                }
            }
        }
    }
}
