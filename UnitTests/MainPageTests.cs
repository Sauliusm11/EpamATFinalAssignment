using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            IWebDriver driver = new FirefoxDriver();
            MainPage page = new MainPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.CompareError(null));
            }
            catch (Exception ex)
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
