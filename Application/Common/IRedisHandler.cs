using System;
using System.Threading.Tasks;

namespace Application.Common
{
    public interface IRedisHandler
    {
        string PrepareActivityKey();
        Task<bool> SetData(string ActivityId, string CustomerEmail);
        Task<string> GetData(string ActivityId);
        void DeleteData(string ActivityId);
        Task<string> GetJwtIssuerKey();
    }
}

