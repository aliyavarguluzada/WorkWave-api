using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;
using IDatabase = StackExchange.Redis.IDatabase;

namespace WorkWaveApp.Infrastructure.Services
{
    internal class CacheService : ICacheService
    {
        private IDatabase _cacheDb;

        public CacheService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379, abortConnect=false");

            _cacheDb = redis.GetDatabase();

        }

        public T GetData<T>(string key)
        {
            var value = _cacheDb.StringGet(key);
            var op = new JsonSerializerOptions();
            op.ReferenceHandler = ReferenceHandler.IgnoreCycles;

            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value,op);
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
