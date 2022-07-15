using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class AboutPage : PageObject
    {
        public AboutPage(IWebDriver webDriver) : base(webDriver, "Home/About") { }

        public EnsekPage FindOutMore()
        {
            webDriver.FindElement(By.ClassName("btn btn-primary btn-lg"));
            return new EnsekPage(webDriver);
        }
    }
}
