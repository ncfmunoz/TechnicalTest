using Framework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using Util;

namespace Framework
{
    public class Driver
    {
        public string baseUrl { private set; get; }
        private IWebDriver webDriver;

        public Driver(SystemDto system)
        {
            baseUrl = system.Url;
            ChromeOptions options = new ChromeOptions();

            if (system.Headless) options.AddArgument("headless");

            webDriver = new ChromeDriver(options);
            
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            webDriver.Manage().Window.Maximize();
        }

        public T Goto<T>(T page , bool redirect) where T : PageObject
        {
            if (redirect) webDriver.Navigate().GoToUrl(baseUrl + page.url);
            return page;
        }
        public void Close()
        {
            webDriver.Close();
            webDriver.Quit();
        }
        public void CloseCurrentTab()
        {
            List<string> tabs = new List<string>(webDriver.WindowHandles);
            webDriver.Close();
            webDriver.SwitchTo().Window(tabs[0]);
        }

        public HomePage HomePage(bool redirect = true) => Goto(new HomePage(webDriver), redirect);
        public AboutPage AboutPage(bool redirect = true) => Goto(new AboutPage(webDriver), redirect);
        public ContactPage ContactPage(bool redirect = true) => Goto(new ContactPage(webDriver), redirect);
        public LoginPage LoginPage(bool redirect = true) => Goto(new LoginPage(webDriver), redirect);
        public RegisterAccountPage RegisterAccountPage(bool redirect = true) => Goto(new RegisterAccountPage(webDriver), redirect);
        public BuyEnergyPage BuyEnergy(bool redirect = true) => Goto(new BuyEnergyPage(webDriver), redirect);
    }
}
