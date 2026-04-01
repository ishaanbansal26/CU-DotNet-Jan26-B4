using MongoDB.Driver;
using VoltGearSystem.Models;
using VoltGearSystem.MongoDbSettings;

namespace VoltGearSystem.Repository
{
    public class LaptopRepository : ILaptopRepository
    {
        private IMongoCollection<Laptop> _collection;

        public LaptopRepository(IConfiguration config)
        {
            var settings = config.GetSection("DatabaseSettings").Get<MongoDbSetting>();
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Laptop>(settings.CollectionName);
        }

        public async Task CreateAsync(Laptop laptop)
        {
            await _collection.InsertOneAsync(laptop);
        }

        public async Task<IEnumerable<Laptop>> GetAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}
