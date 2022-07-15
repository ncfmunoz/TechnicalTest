using Framework;
using NUnit.Framework;
using System.Collections;

namespace Tests.UITests
{
    [Parallelizable]
    [TestFixture]
    public class InvalidInputs : TestBase
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

        [TestCaseSource("InvalidValuesCases")]
        public void InvalidValues(string value)
        {
            var buyEnergyPage = driver.BuyEnergy(false);

            var row = buyEnergyPage.GetRow("Gas");
            row.SetRequestValue(value);
            row = buyEnergyPage.GetRow("Gas");

            Assert.IsFalse(row.BuyButtonIsClickable, "Buy button was enabled");
        }

        public static IEnumerable InvalidValuesCases()
        {
            yield return new TestCaseData("").SetName("BP2");
            yield return new TestCaseData("a").SetName("BP3");
            yield return new TestCaseData("-1").SetName("BP4");
            yield return new TestCaseData("!").SetName("BP5");
            yield return new TestCaseData("<script>alert(“hello”)</script>").SetName("BP6");
            yield return new TestCaseData("1.5").SetName("BP7");
            yield return new TestCaseData("3001").SetName("BP9");
            yield return new TestCaseData("345644356543456546").SetName("BP10");
            yield return new TestCaseData("' OR ' 1=1").SetName("BP11");
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
