using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MongoDB.Driver;

namespace MartianRobots.Infrastructure
{
    /// <summary>
    /// The MartianRobotInputMongoDb repository.
    /// </summary>
    public class MartianRobotInputMongoDBRepository : IRepository<MartianRobotsInput>
    {
        private IMongoCollection<MartianRobotsInput> inputs;

        public MartianRobotInputMongoDBRepository(IMongoClient mongoClient, IMongoDBDatabaseSettings mongoDBTodosDatabaseSettings)
        {
            var database = mongoClient.GetDatabase(mongoDBTodosDatabaseSettings.DatabaseName);
            
            inputs = database.GetCollection<MartianRobotsInput>(mongoDBTodosDatabaseSettings.CollectionName);
        }

        public async Task CreateAsync(MartianRobotsInput entity)
        {
            entity.Id = Guid.NewGuid();
            await inputs.InsertOneAsync(entity);
        }
              
        public async Task DeleteAsync(Guid id)
        {
           await inputs.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<MartianRobotsInput>> GetAllAsync()
        {
            return await Task.Run( () => inputs.Find(t => true).ToList().Select(t => t).ToList()) ;
        }

        public async Task<MartianRobotsInput> GetAsync(Guid id)
        {
            return await inputs.Find(t => t.Id == id).FirstAsync();
        }

        public async Task UpdateAsync(Guid id, MartianRobotsInput entity)
        {
           await inputs.ReplaceOneAsync(t => t.Id == id, entity);
        }
    }
}
