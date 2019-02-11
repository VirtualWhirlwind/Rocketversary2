using core.Interfaces;
using infrastructure.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace infrastructure.DB
{
    public class DbContext
    {
        #region DbSets
        public IMongoCollection<ISpaceEvent> SpaceEvents { get; set; }
        #endregion

        #region Properties
        public static string Server { get; set; }

        public IMongoClient Client { get; set; }
        public IMongoDatabase DB { get; set; }
        #endregion

        #region Construct / Destruct
        public DbContext() { SetCollections(); }

        public DbContext(string server)
        {
            Server = server;

            SetCollections();
        }
        #endregion

        #region Methods
        public void SetCollections()
        {
            if (Server == null || string.IsNullOrEmpty(Server)) { return; }

            Client = new MongoClient(Server);
            DB = Client.GetDatabase(new MongoUrl(Server).DatabaseName);

            // Collections Here
            SpaceEvents = DB.GetCollection<ISpaceEvent>(typeof(SpaceEvent).Name);
        }
        #endregion
    }
}