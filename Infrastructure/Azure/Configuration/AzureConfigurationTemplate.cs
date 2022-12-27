using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Azure.Configuration
{
    public class AzureConfigurationTemplate
    {
        public string AzureVaultUrl { get; set; }
        public string AzureVaultSecret { get; set; }
    }
}
