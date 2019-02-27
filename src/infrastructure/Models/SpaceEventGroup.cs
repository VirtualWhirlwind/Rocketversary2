using System.Collections.Generic;
using core.Interfaces;

namespace infrastructure.Models
{
    public class SpaceEventGroup : ISpaceEventGroup
    {
        #region Fields
        protected List<ISpaceEvent> _Current = new List<ISpaceEvent>();
        #endregion

        #region Properties
        public ISpaceEvent Previous { get; set; }

        public List<ISpaceEvent> Current
        {
            get { return _Current; }
            set { _Current = value ?? new List<ISpaceEvent>(); }
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