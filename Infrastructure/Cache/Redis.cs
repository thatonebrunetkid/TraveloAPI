using System;
using System.Threading.Tasks;
using Application.Common;
using StackExchange.Redis;

namespace Infrastructure.Cache
{
    public class Redis : IRedisHandler
    {
        private static readonly ConnectionMultiplexer RedisMultiplexer = ConnectionMultiplexer.Connect("redis-14658.c56.east-us.azure.cloud.redislabs.com:14658, password=i6VQUNjKCMgR7TlWCkC8uHgFF0E1UhRr");
        private IDatabase ConnectionInstance;

        public Redis()
        {
            ConnectionInstance = RedisMultiplexer.GetDatabase();
        }

        public string PrepareActivityKey()
        {
            return Guid.NewGuid().ToString();
        }

        public async Task<bool> SetData(string CustomerEmail, string ActivityId)
        {
            try
            {
                await ConnectionInstance.StringSetAsync(ActivityId, CustomerEmail + "|date|" + DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc));
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public async Task<string> GetData(string ActivityId)
        {
            return await ConnectionInstance.StringGetAsync(ActivityId);
        }

        public async void DeleteData(string ActivityId)
        {
            await ConnectionInstance.KeyDeleteAsync(ActivityId);
        }
    }
}

