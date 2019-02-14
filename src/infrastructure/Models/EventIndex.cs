using core.Interfaces;

namespace infrastructure.Models
{
    public class EventIndex : IEventIndex
    {
        public int PrevDayMonth { get; set; }
        public int PrevDayDay { get; set; }
        public int ThisDayMonth { get; set; }
        public int ThisDayDay { get; set; }
        public int NextDayMonth { get; set; }
        public int NextDayDay { get; set; }
    }
}