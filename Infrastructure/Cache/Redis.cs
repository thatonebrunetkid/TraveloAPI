using System;
using System.Threading.Tasks;
using Application.Common;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Infrastructure.Cache
{
    public class Redis : IRedisHandler
    {
        private readonly ConnectionMultiplexer RedisMultiplexer;
        private IDatabase ConnectionInstance;
        private readonly IConfiguration Configuration;

        public Redis(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
            RedisMultiplexer = ConnectionMultiplexer.Connect(Configuration["Redis:ApiKey"]);
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

