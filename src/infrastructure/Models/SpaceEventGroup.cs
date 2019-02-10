using System.Collections.Generic;
using core.Interfaces;

namespace infrastructure.Models
{
    public class SpaceEventGroup : ISpaceEventGroup
    {
        public ISpaceEvent Previous { get; set; }
        public int PreviousCount { get; set; }

        public IEnumerable<ISpaceEvent> Current { get; set; }
        public int CurrentCount { get; set; }

        public ISpaceEvent Next { get; set; }
        public int NextCount { get; set; }
    }}