using Core_e2e;
using OpenQA.Selenium;

namespace PageObjects
{
    public class LoginPage : BasePage
    {
        protected sealed override string PageUrl { get; set; }

        public LoginPage(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "";
        }

        public LoginPage Login(string username, string password)
        {
            TypeUsername(username);
            TypePassword(password);
            ClickLogin();

            return this;
        }

        // public for a reason, tests may wish to call them
        // separately - for example an "invalid username" test etc
        public LoginPage TypeUsername(string username)
        {
            Driver.FindElement(By.Id("user-name")).SendKeys(username);

            return this;
        }

        public LoginPage TypePassword(string password)
        {
            Driver.FindElement(By.Id("password")).SendKeys(password);

            return this;
        }

        public LoginPage ClickLogin()
        {
            Driver.FindElement(By.Id("login-button")).Click();

            return this;
        }

        public string ReturnPageError()
        {
            return Driver.FindElement(By
                    .XPath("//div[@class='error-message-container error']"))
                .GetAttribute("innerText");
        }
    }
}
