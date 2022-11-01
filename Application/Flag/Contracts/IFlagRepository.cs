using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Flag.Contracts
{
    public interface IFlagRepository
    {
        Task<string> GetFlag(int FlagId);
    }
}
