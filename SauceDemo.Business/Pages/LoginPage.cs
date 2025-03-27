using OpenQA.Selenium;
using SauceDemo.Core.Helper;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Business.Pages
{
    public class LoginPage :  BasePage
    {
        private readonly By usernameField = By.CssSelector("#user-name");
        private readonly By passwordField = By.CssSelector("#password");
        private readonly By loginButton = By.CssSelector("#login-button");
        private readonly By errorMessageContainer = By.CssSelector("div.error-message-container h3");

        public LoginPage(IWebDriver driver) :base(driver)
        {
        }

        public string ErrorMessage => driver.FindElement(errorMessageContainer).Text;

        public void WaitForPageToLoad()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(usernameField));
        }

        public void EnterUsername(string username)
        {
            var element = driver.FindElement(usernameField);
            ClearUserNameField();
            element.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            var element = driver.FindElement(passwordField);
            ClearPasswordField();
            element.SendKeys(password);
        }

        public void ClearUserNameField()
        {
            var element = driver.FindElement(usernameField);
            SeleniumExtensions.ClearFieldsViaKeyboard(element);
        }

        public void ClearPasswordField()
        {
            var element = driver.FindElement(passwordField);
            SeleniumExtensions.ClearFieldsViaKeyboard(element);
        }

        public void ClickLogin()
        {
            wait.Until(driver =>
            {
                IWebElement element = driver.FindElement(loginButton);
                return element != null && element.Enabled;
            });
            driver.FindElement(loginButton).Click();
        }
    }
}