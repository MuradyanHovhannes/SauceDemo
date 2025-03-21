using OpenQA.Selenium;
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

        public void WaitForPageToLoad()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(usernameField));
        }

        public void EnterUsername(string username)
        {
            var element = driver.FindElement(usernameField);
            element.SendKeys(Keys.Control + "A");
            element.SendKeys(Keys.Backspace);
            element.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            var element = driver.FindElement(passwordField);
            element.SendKeys(Keys.Control + "A");
            element.SendKeys(Keys.Backspace);
            element.SendKeys(password);
        }

        public void ClickLogin()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(loginButton));
            driver.FindElement(loginButton).Click();
        }

        public string GetErrorMessage()
           => driver.FindElement(errorMessageContainer).Text;
    }
}