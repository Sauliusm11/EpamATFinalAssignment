using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp;

[assembly: Parallelize]
namespace UnitTests
{
    [TestClass]

    public class LoginPageTests
    {
        [TestMethod]
        public void LoginPageConstructorNullDriverThrows()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new LoginPage(null));
        }

        public static IEnumerable<object[]> DriverData
        {
            get
            {
                return new[]
                {
            new object[] {new FirefoxDriver() },
            new object[] {new EdgeDriver() },
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(DriverData))]
        public void LoginPageOpens(WebDriver driver)
        {
            LoginPage page = new LoginPage(driver);
            string expected = "Swag Labs";
            try
            {
                page.Open();
                Assert.AreEqual(expected, driver.Title);
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
