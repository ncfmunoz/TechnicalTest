using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class ConfirmationPage : PageObject
    {
        public ConfirmationPage(IWebDriver webDriver) : base(webDriver, "") { }

        public string GetConfirmationMessage() => ConfirmationMessage.Text;

        public IWebElement ConfirmationMessage => webDriver.FindElement(By.ClassName("well"));

    }
}
