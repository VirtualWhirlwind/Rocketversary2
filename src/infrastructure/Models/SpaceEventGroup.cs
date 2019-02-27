using System.Collections.Generic;
using core.Interfaces;

namespace infrastructure.Models
{
    public class SpaceEventGroup
    {
        #region Fields
        protected List<SpaceEvent> _Current = new List<SpaceEvent>();
        #endregion

        #region Properties
        public SpaceEvent Previous { get; set; }

        public List<SpaceEvent> Current
        {
            get { return _Current; }
            set { _Current = value ?? new List<SpaceEvent>(); }
        }
        public int CurrentCount
        {
            get
            {
                if (Current != null) { return Current.Count; }
                return 0;
            }
        }   

        public ISpaceEvent Next { get; set; }
        #endregion
    }
}