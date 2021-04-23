using Core_e2e;

namespace PageObjects
{
    public class SutPageObjects
    {
        private DriverManager DriverManager { get; }
        public string SutBaseUrl { get; }

        public SutPageObjects(DriverManager driverManager)
        {
            DriverManager = driverManager;
        }

        public LoginPage LoginPage()
        {
            return new LoginPage(DriverManager);
        }

        public ProductPage ProductPage()
        {
            return new ProductPage(DriverManager);
        }
    }
}