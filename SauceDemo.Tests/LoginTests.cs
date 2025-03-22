using OpenQA.Selenium;
using Xunit.Abstractions;
using SauceDemo.Core.Driver;
using log4net;
using FluentAssertions;
using SauceDemo.Business.Steps;

namespace SauceDemo.Tests
{
    [Collection("Global logger collection")]
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver driver;
        private LoginPageSteps loginPageSteps;
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginTests));

        public LoginTests(ITestOutputHelper output)
        {
            log.Info("Initializing test...");
            driver = WebDriverFactory.CreateWebDriver("Edge");
            driver.Manage().Window.Maximize();
            loginPageSteps = new LoginPageSteps(driver);
            log.Info("Go to Login Page");
            loginPageSteps.GoToLoginPage();
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

            #endregion

            loginPageSteps.EnterUsernameAndPassword(invalidUsernameAndPassword, invalidUsernameAndPassword);
            loginPageSteps.ClearUserNameAndPasswordField();
            loginPageSteps.ClickOnLoginButton();
            var errorMsg = loginPageSteps.GetErrorMessage();
            log.Info($"UC-1 - Error Message: {errorMsg}");
            errorMsg.Should().Contain("Username is required");
        }



        [Fact(DisplayName = "UC-2 - Test Login Form with Username Only (Password missing)")]
        public void UC2_MissingPassword_ShouldShowPasswordRequired()
        {
            #region Parameters

            var invalidUsername = "anyUsername";
            var tempPassword = "temp";

            #endregion

            loginPageSteps.EnterUsernameAndPassword(invalidUsername, tempPassword);
            loginPageSteps.ClearPasswordField();
            loginPageSteps.ClickOnLoginButton();
            var errorMsg = loginPageSteps.GetErrorMessage();
            log.Info($"UC-2 - Error Message: {errorMsg}");
            errorMsg.Should().Contain("Password is required");
        }



        [Theory(DisplayName = "UC-3 - Test Login with Valid Username & Password")]
        [MemberData(nameof(ValidUsernames))]
        public void UC3_ValidCredentials_ShouldLoginSuccessfully(string validUsername)
        {
            #region Parameters

            //Enter valid password here(You can get it from SauceDemo website)
            var password = "";

            #endregion

            loginPageSteps.EnterUsernameAndPassword(validUsername, password);
            loginPageSteps.ClickOnLoginButton();
            log.Info("Login to website");
            driver.Title.Should().Be("Swag Labs", because: "user should be navigated to the dashboard with correct title");
        }

        public void Dispose()
        {
            log.Info("Test completed. Disposing driver...");
            driver.Quit();
            driver.Dispose();
        }
    }
}