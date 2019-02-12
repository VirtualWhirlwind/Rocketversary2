using System;
using core.Interfaces;
using infrastructure.Models;
using MongoDB.Driver;

namespace infrastructure.DB
{
    public partial interface IDbMgr
    {
        void SaveSpaceEvent(ISpaceEvent save);
        ISpaceEvent GetSpaceEventById(string id);
        ISpaceEventGroup GetGroupForDate(DateTime forDate);
    }
    public partial class DbMgr : IDbMgr
    {
        public void SaveSpaceEvent(ISpaceEvent save) => Context.SpaceEvents.ReplaceOne(Filter(save._id), save, Options);

        public ISpaceEvent GetSpaceEventById(string id)
        {
            var Result = Context.SpaceEvents.Find(Filter(id)).FirstOrDefault();
            return Result;
        }

        public ISpaceEventGroup GetGroupForDate(DateTime forDate)
        {
            var Result = new SpaceEventGroup();

            // Exact

            // Next after Exact if needed
            if (Result.CurrentCount == 0)
            {
                
            }

            // Previous

            // Later

            return Result;
        }
    }
}