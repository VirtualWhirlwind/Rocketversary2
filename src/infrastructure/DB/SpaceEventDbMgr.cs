using System;
using core.Interfaces;
using infrastructure.Models;
using infrastructure.Support;
using MongoDB.Bson;
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

            // Exact Day
            var DayIndex = Utilities.DayIndex(forDate);
            Result.Current = Context.SpaceEvents.Find(new BsonDocument("DayIndex", DayIndex)).ToList();

            // Next Day after Exact Day if needed
            if (Result.CurrentCount == 0)
            {
                // Check for next
                DayIndex = Context.SpaceEvents.Find<ISpaceEvent>(s => s.DayIndex > DayIndex).SortBy(s => s.DayIndex).Project(s => s.DayIndex).FirstOrDefault();

                // If none, start from 1/1
                if (DayIndex == 0)
                {
                    DayIndex = Context.SpaceEvents.Find<ISpaceEvent>(s => s.DayIndex > 0).SortBy(s => s.DayIndex).Project(s => s.DayIndex).FirstOrDefault();
                }

                // Grab Group
                Result.Current = Context.SpaceEvents.Find<ISpaceEvent>(s => s.DayIndex == DayIndex).ToList();
            }

            // Previous
            Result.Previous = Context.SpaceEvents.Find<ISpaceEvent>(s => s.DayIndex < DayIndex).SortByDescending(s => s.Date).FirstOrDefault();
            if (Result.Previous == null)
            {
                Result.Previous = Context.SpaceEvents.Find<ISpaceEvent>(s => s.DayIndex < 367).SortByDescending(s => s.Date).FirstOrDefault();
            }

            // Later
            Result.Next = Context.SpaceEvents.Find<ISpaceEvent>(s => s.DayIndex > DayIndex).SortBy(s => s.Date).FirstOrDefault();
            if (Result.Next == null)
            {
                Result.Next = Context.SpaceEvents.Find<ISpaceEvent>(s => s.DayIndex > 0).SortBy(s => s.Date).FirstOrDefault();
            }

            return Result;
        }
    }
}