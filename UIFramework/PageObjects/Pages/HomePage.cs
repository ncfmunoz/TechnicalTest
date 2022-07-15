using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class HomePage : PageObject
    {
        public HomePage(IWebDriver webDriver) : base(webDriver, "Home/Contact") { }

        public AboutPage AboutPage()
        {
            AboutButton.Click();
            return new AboutPage(webDriver);
        }
        public ContactPage ContactPage()
        {
            ContactButton.Click();
            return new ContactPage(webDriver);
        }
        public RegisterAccountPage Register()
        {
            RegisterButton.Click();
            return new RegisterAccountPage(webDriver);
        }
        public LoginPage Login()
        {
            LoginButton.Click();
            return new LoginPage(webDriver);
        }
        public EnsekPage FindOutMore()
        {
            LoginButton.Click();
            return new EnsekPage(webDriver);
        }
        public BuyEnergyPage Buy()
        {
            BuyEnergy.Click();
            return new BuyEnergyPage(webDriver);
        }

        public IWebElement AboutButton => webDriver.FindElement(By.XPath("//*[@class=\"nav navbar-nav\"]/li[2]"));
        public IWebElement ContactButton => webDriver.FindElement(By.XPath("//*[@class=\"nav navbar-nav\"]/li[3]"));
        public IWebElement RegisterButton => webDriver.FindElement(By.Id("registerLink"));
        public IWebElement LoginButton => webDriver.FindElement(By.Id("loginLink"));
        public IWebElement FindOutMoreButton => webDriver.FindElement(By.ClassName("btn btn-primary btn-lg"));
        public IWebElement BuyEnergy => webDriver.FindElement(By.ClassName("//*[@href=\"/Energy/Buy\"]"));

    }
}
