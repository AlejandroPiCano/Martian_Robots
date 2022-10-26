using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MongoDB.Driver;

namespace MartianRobots.Infrastructure
{
    /// <summary>
    /// The MartianRobotOutputMongoDb repository.
    /// </summary>
    public class MartianRobotOutputMongoDBRepository : IRepository<MartianRobotsOutput>
    {
        private IMongoCollection<MartianRobotsOutput> outputs;

        public MartianRobotOutputMongoDBRepository(IMongoClient mongoClient, IMongoDBDatabaseSettings mongoDBTodosDatabaseSettings)
        {
            var database = mongoClient.GetDatabase(mongoDBTodosDatabaseSettings.DatabaseName);
            
            outputs = database.GetCollection<MartianRobotsOutput>(mongoDBTodosDatabaseSettings.CollectionNameOutput);
        }

        public async Task CreateAsync(MartianRobotsOutput entity)
        {
            entity.Id = Guid.NewGuid();
            await outputs.InsertOneAsync(entity);
        }
              
        public async Task DeleteAsync(Guid id)
        {
           await outputs.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<MartianRobotsOutput>> GetAllAsync()
        {
            return await Task.Run( () => outputs.Find(t => true).ToList().Select(t => t).ToList()) ;
        }

        public async Task<MartianRobotsOutput> GetAsync(Guid id)
        {
            return await outputs.Find(t => t.Id == id).FirstAsync();
        }

        public async Task UpdateAsync(Guid id, MartianRobotsOutput entity)
        {
           await outputs.ReplaceOneAsync(t => t.Id == id, entity);
        }
    }
}
