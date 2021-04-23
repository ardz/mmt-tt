using System;
using Core_e2e;
using OpenQA.Selenium;
using PageObjects;

namespace GuiTests_e2e
{
    public class GuiTestFixture : IDisposable
    {
        private DriverManager DriverManager { get; }
        protected readonly IWebDriver Driver;
        protected SutPageObjects SauceDemoPages { get; }

        protected GuiTestFixture()
        {
            var testConfig = new Config().TestConfiguration;

            DriverManager = 
                new DriverManager(testConfig["e2e:browser"], 
                    testConfig["e2e:suturl"], 
                    int.Parse(testConfig["e2e:timeout"]));

            Driver = DriverManager.CreateDriver();

            SauceDemoPages = new SutPageObjects(DriverManager);
        }

        protected void Login()
        {
            SauceDemoPages.LoginPage().NavigateTo();
            SauceDemoPages.LoginPage()
                .TypeUsername("standard_user")
                .TypePassword("secret_sauce")
                .ClickLogin();
        }

        public void Dispose()
        {
            DriverManager.Driver.Quit();
        }
    }
}