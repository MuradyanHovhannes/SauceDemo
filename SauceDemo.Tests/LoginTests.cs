using OpenQA.Selenium;
using Xunit.Abstractions;
using SauceDemo.Core.Driver;
using log4net;
using FluentAssertions;
using SauceDemo.Business.Pages;

namespace SauceDemo.Tests
{
    [Collection("Global logger collection")]
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver driver;
        private LoginPage loginPage;
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginTests));
        private readonly string url = "https://www.saucedemo.com/";

        public LoginTests(ITestOutputHelper output)
        {
            log.Info("Initializing test...");
            driver = WebDriverFactory.CreateWebDriver("Edge");
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            log.Info("Go to Login Page");
            loginPage.GoToPage(url);
            loginPage.WaitForPageToLoad();
        }

        public static IEnumerable<object[]> ValidUsernames()
        {
            yield return new object[] { "standard_user" };
            yield return new object[] { "locked_out_user" };
            yield return new object[] { "problem_user" };
            yield return new object[] { "performance_glitch_user" };
            yield return new object[] { "error_user" };
            yield return new object[] { "visual_user" };
        }

        [Fact(DisplayName = "UC-1 - Test Login Form with Empty Credentials")]
        public void UC1_EmptyCredentials_ShouldShowUsernameRequired()
        {
            #region Parameters

            var invalidUsernameAndPassword = "temp";
            var expectedErrorMessage = "Username is required";

            #endregion
            loginPage.EnterUsername(invalidUsernameAndPassword);
            loginPage.ClearUserNameField();
            loginPage.EnterPassword(invalidUsernameAndPassword);
            loginPage.ClearPasswordField();
            loginPage.ClickLogin();
            var errorMsg = loginPage.ErrorMessage;
            log.Info($"UC-1 - Error Message: {errorMsg}");
            errorMsg.Should().Contain(expectedErrorMessage, "Incorrect error message was shown on Login page after entering empty credentials!");
        }



        [Fact(DisplayName = "UC-2 - Test Login Form with Username Only (Password missing)")]
        public void UC2_MissingPassword_ShouldShowPasswordRequired()
        {
            #region Parameters

            var invalidUsername = "anyUsername";
            var tempPassword = "temp";
            var expectedErrorMessage = "Password is required";

            #endregion

            loginPage.EnterUsername(invalidUsername);
            loginPage.EnterPassword(tempPassword);
            loginPage.ClearPasswordField();
            loginPage.ClickLogin();
            var errorMsg = loginPage.ErrorMessage;
            log.Info($"UC-2 - Error Message: {errorMsg}");
            errorMsg.Should().Contain(expectedErrorMessage, "Incorrect error message was shown on Login page after entering empty password!");
        }



        [Theory(DisplayName = "UC-3 - Test Login with Valid Username & Password")]
        [MemberData(nameof(ValidUsernames))]
        public void UC3_ValidCredentials_ShouldLoginSuccessfully(string validUsername)
        {
            #region Parameters

            //Enter valid password here(You can get it from SauceDemo website)
            var password = "";
            var expectedTitle = "Swag Labs";

            #endregion
            loginPage.EnterUsername(validUsername);
            loginPage.EnterPassword(password);
            loginPage.ClickLogin();
            log.Info("Login to website");
            driver.Title.Should().Be(expectedTitle, "Titile is not correct!");
        }

        public void Dispose()
        {
            log.Info("Test completed. Disposing driver...");
            driver.Quit();
            driver.Dispose();
        }
    }
}