using System.Collections.Generic;

namespace core.Interfaces
{
    public interface ISpaceEventGroup
    {
        ISpaceEvent Previous { get; set; }

        List<ISpaceEvent> Current { get; set; }
        int CurrentCount { get; }

        ISpaceEvent Next { get; set; }
    }
}