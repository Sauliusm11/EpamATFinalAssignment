using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using TestingApp;

namespace UnitTests
{
    [TestClass]

    internal class MainPageTests
    {
        [TestMethod]
        public void MainPageConstructorNullDriverThrows()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new MainPage(null));
        }
        [TestMethod]
        public void MainPageCompareErrorNullMessageThrows()
        {
            FirefoxDriver driver = new FirefoxDriver();
            MainPage page = new MainPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.CompareError(null));
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                driver.Quit();
            }
        }
    }

}
