using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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
                return
                [
                    [new FirefoxDriver()],
                    [new EdgeDriver()],
                ];
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
            EdgeDriver driver = new EdgeDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().FindInputFields().InputCredentials(null, "Pass"));
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
        public void LoginPageInputNullPassThrows()
        {
            FirefoxDriver driver = new FirefoxDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().FindInputFields().InputCredentials("Name", null));
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
        public void LoginPageInputNullUserElementThrows()
        {
            EdgeDriver driver = new EdgeDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().InputCredentials("Name", "Pass"));
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
        public void LoginPageInputNullPassElementThrows()
        {
            FirefoxDriver driver = new FirefoxDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().InputCredentials("Name", "Pass"));
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
        public void LoginPageClearUsernameThrows()
        {
            EdgeDriver driver = new EdgeDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().ClearUsername());
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
        public void LoginPageClearPasswordThrows()
        {
            FirefoxDriver driver = new FirefoxDriver();
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().ClearPassword());
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
        public void LoginPageUseCase1(IWebDriver driver)
        {
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.IsTrue(Program.UseCase1(page));
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
        [DynamicData(nameof(DriverData))]
        public void LoginPageUseCase2(IWebDriver driver)
        {
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.IsTrue(Program.UseCase2(page));
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
        [DynamicData(nameof(DriverData))]
        public void LoginPageUseCase3(IWebDriver driver)
        {
            LoginPage page = new LoginPage(driver);
            try
            {
                Assert.IsTrue(Program.UseCase3(page));
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
    }
}
