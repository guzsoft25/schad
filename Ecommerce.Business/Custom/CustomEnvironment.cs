using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Enums;

namespace Ecommerce.Business.Custom
{
    public class CustomEnvironment : ICustomEnvironment
    {
        private readonly ICustomSettings settings;

        public CustomEnvironment(ICustomSettings settings)
        {
            this.settings = settings;
        }

        public Enviro GetEnvironment()
        {
            bool isDevelopment = bool.Parse(settings.GetSetting("isDevelopment"));

            if (isDevelopment) {
                return Enviro.Testing;
            }
            else {
                return Enviro.Production;
            }
        }
    }
}


