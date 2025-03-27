using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemo.Business.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        private readonly TimeSpan timeout = TimeSpan.FromSeconds(10);

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, timeout);
        }

        public void GoToPage(string url)
           => driver.Navigate().GoToUrl(url);
    }
}
