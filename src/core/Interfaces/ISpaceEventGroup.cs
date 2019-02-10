using System.Collections.Generic;

namespace core.Interfaces
{
    public interface ISpaceEventGroup
    {
        ISpaceEvent Previous { get; set; }
        int PreviousCount { get; set; }

        IEnumerable<ISpaceEvent> Current { get; set; }
        int CurrentCount { get; set; }

        ISpaceEvent Next { get; set; }
        int NextCount { get; set; }
    }
}