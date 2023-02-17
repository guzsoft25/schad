using Ecommerce.Shared.Contracts;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Business.Custom
{
    public class CustomSettings : ICustomSettings
    {
        private readonly IConfiguration configuration;

        public CustomSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetSetting(string name)
        {
            bool isConnectionString = !string.IsNullOrEmpty(configuration.GetConnectionString(name));

            if (isConnectionString) {
                return configuration.GetConnectionString(name);
            }
            else {
                return configuration.GetSection($"Settings:{name}").Value;
            }
        }
    }
}
