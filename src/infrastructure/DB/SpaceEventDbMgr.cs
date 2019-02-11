using core.Interfaces;

namespace infrastructure.DB
{
    public partial interface IDbMgr
    {
        void SaveSpaceEvent(ISpaceEvent save);
    }
    public partial class DbMgr : IDbMgr
    {
        public void SaveSpaceEvent(ISpaceEvent save) => Context.SpaceEvents.ReplaceOne(Filter(save._id), save, Options);
    }
}