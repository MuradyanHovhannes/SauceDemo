using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SauceDemo.Core.Driver
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browserName)
        {
            return browserName.ToLower() switch
            {
                "edge" => new EdgeDriver(),
                "firefox" => new FirefoxDriver(),
                _ => throw new ArgumentException($"Browser not supported: {browserName}")
            };
        }
    }
}