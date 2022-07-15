using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class ContactPage : PageObject
    {
        public ContactPage(IWebDriver webDriver) : base(webDriver, "Home/Contact") { }

    }
}
