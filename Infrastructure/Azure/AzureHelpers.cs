using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Infrastructure.Azure.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Azure
{
    public class AzureHelpers
    {
        private readonly AzureConfigurationTemplate Template;
        public AzureHelpers(IConfiguration Configuration, AzureKeyVaultConfigType ConfigType)
        {
            Template = new AzureConfigurationTemplate();
            Template.AzureVaultUrl = Configuration.GetValue<string>("AzureKeyVault:KeyVaultUrl");
            switch(ConfigType)
            {
                case AzureKeyVaultConfigType.JwtToken:
                    {
                        Template.AzureVaultSecret = Configuration.GetValue<string>("AzureKeyVault:KeyVaultSecret");
                        break;
                    }
                case AzureKeyVaultConfigType.TwilioApiKey:
                    {
                        Template.AzureVaultSecret = Configuration.GetValue<string>("AzureKeyVault:TwilioEmailApiKey");
                        break;
                    }
                case AzureKeyVaultConfigType.AzureConnectionString:
                    {
                        Template.AzureVaultSecret = Configuration.GetValue<string>("AzureKeyVault:AzureConnectionString");
                        break;
                    }
                case AzureKeyVaultConfigType.Redis:
                    {
                        Template.AzureVaultSecret = Configuration.GetValue<string>("AzureKeyVault:Redis");
                        break;
                    }
            }

        }

        public async Task<string> GetKeyVaultValueFromAzure()
        {
            var client = new SecretClient(new Uri(Template.AzureVaultUrl), new DefaultAzureCredential());
            var secret =  await client.GetSecretAsync(Template.AzureVaultSecret);
            return secret.Value.Value;
        }

        
    }
}
