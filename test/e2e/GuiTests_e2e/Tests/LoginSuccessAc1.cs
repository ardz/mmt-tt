using Xbehave;
using Xunit;

namespace GuiTests_e2e.Tests
{
    // The test documentation says these are user stories but they're not, they're test scenarios?
    // Also, they're breaking a number of fundamental rules in Gherkin - use of the word "I" for example
    // The way they're written is also anti-pattern - the test steps are now "hard coded" to the UI.
    // If the UI changes the tests steps effectively could become invalid.

    // It's best to write a user story which describes behavior *not* UI elements - you'd have to go back
    // and rewrite the test steps now if the UI changes. It also means that behaviours could be tested underneath
    // the UI depending on how the application has been architected - much better than having to rely on the UI.

    public class LoginSuccessAc1 : GuiTestFixture
    {
        [Scenario]
        [InlineData("Epic sadface: Username is required", "", "")]
        [InlineData("Epic sadface: Password is required", "nouser1", "")]
        [InlineData("Epic sadface: Username is required", "", "nopass1")]
        [InlineData("Epic sadface: Username and password do not match any user in this service", "nouser1", "nopass1")]
        // there's little value in writing a test like this with a heavy framework like Selenium :/
        public void InvalidCredentials_Expect_LoginError(string expectedError, string username, string password)
        {
            "Given that I am on the login page"
                .x(() => { SauceDemoPages.LoginPage().NavigateTo(); });

            $"When I click “Log in” with {username} and {password}"
                .x(() => { SauceDemoPages.LoginPage().Login(username, password); });

            "Then an error will be thrown below the form stating “Epic sadface: Username is required”"
                .x(() =>
                {
                    Assert.Equal(expectedError, SauceDemoPages.LoginPage().ReturnPageError());
                });
        }

        [Scenario]
        [InlineData("standard_user", "secret_sauce", "/inventory.html")]
        public void ValidCredentials_Expect_LoginSuccess(string username, string password, string expectedPage)
        {
            "Given that I have entered a valid username and password"
                .x(() =>
                {
                    SauceDemoPages.LoginPage().NavigateTo();
                    SauceDemoPages.LoginPage()
                        .TypeUsername(username)
                        .TypePassword(password);
                });

            "When I attempt to login"
                .x(() =>
                {
                    SauceDemoPages.LoginPage().ClickLogin();
                });

            $"Then it will successfully redirect me to {expectedPage}”"
                .x(() =>
                {
                    var actualPage = Driver.Url;
                    Assert.Contains(expectedPage, actualPage);
                });
        }
    }
}
