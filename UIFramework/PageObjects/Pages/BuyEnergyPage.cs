using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.PageObjects
{
    public class BuyEnergyPage : PageObject
    {
        public BuyEnergyPage(IWebDriver webDriver) : base(webDriver, "Energy/Buy") { }

        public BuyEnergyPage ResetData()
        {
            ResetDataButton.Click();
            return new BuyEnergyPage(webDriver);
        }

        public EnergyRow GetRow(string energyType) => GetTableData().FirstOrDefault(a => a.EnergyType.Equals(energyType));

        public List<EnergyRow> GetTableData()
        {
            var tableBody = webDriver.FindElement(By.ClassName("table")).FindElement(By.TagName("tbody"));
            List<IWebElement> rows = tableBody.FindElements(By.TagName("tr")).ToList();

            List<EnergyRow> tableData = new List<EnergyRow>();

            rows.ForEach(a => 
            {
                EnergyRow row = new EnergyRow(webDriver);

                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.1);

                row.EnergyType = a.FindElement(By.XPath("td[1]")).Text;
                row.Price = a.FindElement(By.XPath("td[2]")).Text;
                row.QuantityAvailable = a.FindElement(By.XPath("td[3]")).Text;
                try
                {
                    row.UnitsRequired = a.FindElement(By.XPath("td[4]/input"));
                    row.CanRequest = true;
                }
                catch
                {
                    row.UnitsRequired = null;
                    row.CanRequest = false;
                }
                try
                {
                    row.Buy = a.FindElement(By.Name("Buy"));
                }
                catch
                {
                    row.Buy = null;
                }

                tableData.Add(row);
            });

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return tableData;
        }

        IWebElement ResetDataButton => webDriver.FindElement(By.Name("Reset"));
    }


    public class EnergyRow : BuyEnergyPage
    {
        public string EnergyType { get; set; }
        public string Price { get; set; }
        public string QuantityAvailable { get; set; }
        public IWebElement? UnitsRequired { get; set; }
        public IWebElement? Buy { get; set; }
        public bool CanRequest { get; set; }

        public EnergyRow(IWebDriver webDriver) : base(webDriver) { }

        public void SetRequestValue(string value)
        {
            UnitsRequired.SendKeys(Keys.Control + "a");
            UnitsRequired.SendKeys(Keys.Delete);
            UnitsRequired.SendKeys(value);
        }

        public bool BuyButtonIsClickable => Buy.Enabled;
        public ConfirmationPage ClickBuy()
        {
            Buy.Click();
            return new ConfirmationPage(webDriver);
        }
    }
}
