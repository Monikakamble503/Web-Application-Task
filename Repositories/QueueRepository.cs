using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        private readonly IMongoCollection<QueueRecord> _collection;

        public QueueRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase("app");
            _collection = database.GetCollection<QueueRecord>("QueueData");
        }

        public async Task<List<QueueRecord>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(QueueRecord record) =>
            await _collection.InsertOneAsync(record);
    }
}