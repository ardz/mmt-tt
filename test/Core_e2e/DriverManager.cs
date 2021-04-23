using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core_e2e
{
    public class DriverManager
    {
        private static int _impWaitTimeout;
        private static string _browserName;
        private IWebDriver _driver;
        public string SutUrl { get; }

        public IWebDriver Driver
        {
            get
            {
                if (_driver != null)
                {
                    return _driver;
                }

                _driver = CreateDriver();

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_impWaitTimeout);

                return _driver;
            }
        }

        public IWebDriver CreateDriver()
        {
            switch (_browserName)
            
            {
                case "chrome":
                    
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(
                        "test-type",
                        "chrome.switches",
                        "--disable-extensions",
                        "--start-maximized");

                    chromeOptions.
                        AddUserProfilePreference("credentials_enable_service", false);
                    chromeOptions.
                        AddUserProfilePreference("password_manager_enabled", false);

                    _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(),
                        chromeOptions, TimeSpan.FromSeconds(_impWaitTimeout));
                    
                    break;
            }

            return _driver;
        }

        public DriverManager(string browserName, string sutUrl, int impWaitTimeout)
        {
            _browserName = browserName;
            _impWaitTimeout = impWaitTimeout;
            SutUrl = sutUrl;
        }
    }
}
