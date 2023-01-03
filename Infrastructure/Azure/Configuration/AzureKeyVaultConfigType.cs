using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Azure.Configuration
{
    public enum AzureKeyVaultConfigType
    {
        JwtToken = 0,
        AzureConnectionString = 1,
        TwilioApiKey = 2,
        Redis = 3
    }
}
