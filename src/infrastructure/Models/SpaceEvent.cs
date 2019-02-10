using System;
using System.Collections.Generic;
using core.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace infrastructure.Models
{
    public class SpaceEvent : ISpaceEvent
    {
        #region Fields
        protected string __id = ObjectId.GenerateNewId().ToString();
        #endregion

        #region Properties
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string _id
        {
            get { return __id; }
            set { __id = value; }
        }
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        #endregion

        #region Convenience Properties
        [BsonIgnore]
        public int Year { get { return Date.Year; } }
        [BsonIgnore]
        public int Month { get { return Date.Month; } }
        [BsonIgnore]
        public int Day { get { return Date.Day; } }
        [BsonIgnore]
        public string GenericDate { get { return Date.ToString("yyyy-MM-dd"); } }

        [BsonIgnore]
        public DateTime ConvenienceDate { get { var Result = new DateTime(DateTime.Now.Year, Date.Month, Date.Day, Date.Hour, Date.Minute, Date.Second); return Result; } }
        #endregion
    }
}
