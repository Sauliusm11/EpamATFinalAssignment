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
        public void LoginPageOpens(IWebDriver driver)
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

        [TestMethod]
        [DynamicData(nameof(DriverData))]
        public void LoginPageLocatesInputFields(IWebDriver driver)
        {
            LoginPage page = new LoginPage(driver);
            try
            {
                page.Open().Maximize().FindInputFields();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [TestMethod]
        public void LoginPageInputNullUserThrows()
        {
            IWebDriver driver = new EdgeDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().FindInputFields().InputCredentials(null, "Pass"));
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
        [TestMethod]
        public void LoginPageInputNullPassThrows()
        {
            IWebDriver driver = new FirefoxDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().FindInputFields().InputCredentials("Name", null));
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

        [TestMethod]
        public void LoginPageInputNullUserElementThrows()
        {
            IWebDriver driver = new EdgeDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().InputCredentials("Name", "Pass"));
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
        [TestMethod]
        public void LoginPageInputNullPassElementThrows()
        {
            IWebDriver driver = new FirefoxDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().InputCredentials("Name", "Pass"));
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
        [TestMethod]
        public void LoginPageClearUsernameThrows()
        {
            IWebDriver driver = new EdgeDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().ClearUsername());
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
        [TestMethod]
        public void LoginPageClearPasswordThrows()
        {
            IWebDriver driver = new FirefoxDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().ClearPassword());
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
