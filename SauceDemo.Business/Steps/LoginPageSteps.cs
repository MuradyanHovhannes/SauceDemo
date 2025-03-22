using OpenQA.Selenium;
using SauceDemo.Business.Pages;

namespace SauceDemo.Business.Steps
{
    public class LoginPageSteps
    {
        private readonly IWebDriver driver;
        private LoginPage loginPage;

        public LoginPageSteps(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
        }

        public void GoToLoginPage()
        {
            var url = "https://www.saucedemo.com/";
            loginPage.GoToPage(url);
            loginPage.WaitForPageToLoad();
        }

        public void EnterUsernameAndPassword(string username, string password)
        {
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
        }

        public void ClickOnLoginButton()
          => loginPage.ClickLogin();

        public string GetErrorMessage()
          => loginPage.GetErrorMessage();

        public void ClearPasswordField()
          => loginPage.ClearPasswordField();

        public void ClearUserNameAndPasswordField()
        {
            loginPage.ClearUserNameField();
            loginPage.ClearPasswordField();
        }
    }
}
