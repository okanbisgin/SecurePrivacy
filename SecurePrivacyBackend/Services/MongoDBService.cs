using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SecurePrivacyBackend.Models;

namespace SecurePrivacyBackend.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetUsersAsync() =>
            await _usersCollection.Find(_ => true).ToListAsync();

        public async Task CreateUserAsync(User user) =>
            await _usersCollection.InsertOneAsync(user);
    }
}
