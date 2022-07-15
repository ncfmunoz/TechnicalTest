using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class LoginPage : PageObject
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver, "Account/Login") { }

    }
}
