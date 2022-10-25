using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Infrastructure
{
    /// <summary>
    /// The MongoDBDatabaseSettings class.
    /// </summary>
    public class MongoDBDatabaseSettings : IMongoDBDatabaseSettings
    {
        public string CollectionName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;
    }
}
