using Microsoft.Extensions.Configuration;

namespace Pasticceria.Data.Service
{
    public class AppSettings
    {
        private readonly IConfiguration _config;
        public AppSettings(IConfiguration config)
        {
            _config = config;
        }
        public string GetBaseUrl()
        {
            return _config.GetValue<string>("Setup:BaseUrl");
        }
    }
}
