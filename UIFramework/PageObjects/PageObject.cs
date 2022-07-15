using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public abstract class PageObject
    {
        public string url { protected set; get; }
        protected IWebDriver webDriver;

        protected PageObject(IWebDriver webDriver, string url)
        {
            this.webDriver = webDriver;
            this.url = url;
        }
        protected PageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
    }
}
