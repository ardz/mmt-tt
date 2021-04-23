using Microsoft.Extensions.Configuration;

namespace GuiTests_e2e
{
    public class Config
    {
        public IConfiguration TestConfiguration { get; }
        
        public Config()
        {
            TestConfiguration = new ConfigurationBuilder()
                .AddJsonFile(System.IO.Directory.GetCurrentDirectory() + "\\appsettings.json")
                .Build();
        }
    }
}