using System;
using core.Interfaces;
using infrastructure.DB;
using infrastructure.Models;
using MongoDB.Bson;

namespace infrastructure.Tests.FakeDB
{
    public class FakeDbMgr : IDbMgr
    {
        public BsonDocument Filter() { return null; }

        public BsonDocument Filter(string filter) { return null; }

        public BsonDocument Filter(string key, BsonValue value) { return null; }

        public ISpaceEventGroup GetGroupForDate(DateTime forDate)
        {
            var SE1 = new SpaceEvent()
            {
                Name = "Test Event 1",
                Country = "United States",
                Date = new DateTime(1969, 1, 1)
            };
            var SE2 = new SpaceEvent()
            {
                Name = "Test Event 2",
                Country = "United States",
                Date = new DateTime(1980, 5, 1)
            };
            var SE2_2 = new SpaceEvent()
            {
                Name = "Test Event 2_2",
                Country = "United States",
                Date = new DateTime(1981, 5, 1)
            };
            var SE3 = new SpaceEvent()
            {
                Name = "Test Event 3",
                Country = "United States",
                Date = new DateTime(2000, 12, 1)
            };

            var Result = new SpaceEventGroup();
            Result.Previous = SE1;
            Result.Current.Add(SE2);
            Result.Current.Add(SE2_2);
            Result.Next = SE3;

            return Result;
        }

        public ISpaceEvent GetSpaceEventById(string id)
        {
            return new SpaceEvent()
            {
                _id = new ObjectId(id),
                Name = "Test Event 1",
                Country = "United States",
                Date = new DateTime(1969, 1, 1)
            };
        }

        public void SaveSpaceEvent(SpaceEvent save) { }
    }
}