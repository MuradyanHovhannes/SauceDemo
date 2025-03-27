using OpenQA.Selenium;

namespace SauceDemo.Core.Helper
{
    public static class SeleniumExtensions
    {
        public static void ClearFieldsViaKeyboard(IWebElement element)
        {
            element.SendKeys(Keys.Control + "A");
            element.SendKeys(Keys.Backspace);
        }
    }
}