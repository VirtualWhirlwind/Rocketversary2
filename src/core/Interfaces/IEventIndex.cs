namespace core.Interfaces
{
    public interface IEventIndex
    {
        int PrevDayMonth { get; set; }
        int PrevDayDay { get; set; }
        int ThisDayMonth { get; set; }
        int ThisDayDay { get; set; }
        int NextDayMonth { get; set; }
        int NextDayDay { get; set; }
    }
}