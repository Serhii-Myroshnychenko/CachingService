using CachingService.Data.Contracts;
using CachingService.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace CachingService.Data.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        public PlatformRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = _redis.GetDatabase();
        }
        public async void CreatePlatform(Platform platfrom)
        {
            if(platfrom == null) { throw new ArgumentNullException(nameof(platfrom)); }
            var serialPlat = JsonSerializer.Serialize(platfrom);
            await _database.StringSetAsync(platfrom.Id, serialPlat);
        }
        public IEnumerable<Platform> GetAllPlatforms()
        {
            throw new NotImplementedException();
        }

        public Platform? GetPlatformById(string id)
        {
            var platfrom = _database.StringGet(id);
            if(!string.IsNullOrEmpty(platfrom)) { return JsonSerializer.Deserialize<Platform>(platfrom); }
            return null;
        }
    }
}
