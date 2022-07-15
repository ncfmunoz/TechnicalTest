using Framework;
using NUnit.Framework;
using System.Collections;

namespace Tests.UITests
{
    [Parallelizable]
    [TestFixture]
    public class ValidInputs : TestBase
    {
        Driver driver;

        [OneTimeSetUp]
        public void ClassInit()
        {
            driver = new Driver(System);
        }

        [SetUp]
        public void SetUp()
        {
            driver.BuyEnergy().ResetData();
        }

        [TestCaseSource("ValidValuesCases")]
        public void ValidValues(int value)
        {
            var buyEnergyPage = driver.BuyEnergy(false);

            var row = buyEnergyPage.GetRow("Gas");
            row.SetRequestValue(value.ToString());
            var confirmationPage = row.ClickBuy();

            string confirmationText = confirmationPage.GetConfirmationMessage();

            Assert.IsTrue(confirmationText.Contains($"Thank you for your purchase of {value} units of Gas"));
            Assert.IsTrue(confirmationText.Contains($"There are now {3000 - value} units of Gas"));
        }
        
        public static IEnumerable ValidValuesCases()
        {
            yield return new TestCaseData(1).SetName("BP1");
            yield return new TestCaseData(3000).SetName("BP8");
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
