using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class RegisterAccountPage : PageObject
    {
        public RegisterAccountPage(IWebDriver webDriver) : base(webDriver, "Account/Register") { }

    }
}
