using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;
using IDatabase = StackExchange.Redis.IDatabase;

namespace WorkWaveApp.Infrastructure.Services
{
    internal class CacheService : ICacheService
    {
        private IDatabase _cacheDb;
        private readonly IConfiguration _configuration;
        public CacheService(IConfiguration configuration)
        {
            _configuration = configuration;
            var redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
        }

        public T GetData<T>(string key)
        {
            var value = _cacheDb.StringGet(key);

            if (String.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

        public object RemoveData(string key)
        {
            var exists = _cacheDb.KeyExists(key);
            if (exists)
                return _cacheDb.KeyDelete(key);
            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expirytime = expirationTime.DateTime.Subtract(DateTime.Now);

            return _cacheDb.StringSet(key, JsonSerializer.Serialize<T>(value), expirytime);

        }
    }
}
