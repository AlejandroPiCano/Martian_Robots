using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Infrastructure
{
    /// <summary>
    /// The IMongoDBDatabaseSettings interface
    /// </summary>
    public interface IMongoDBDatabaseSettings
    {
        public string CollectionNameInput { get; set; }

        public string CollectionNameOutput { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
