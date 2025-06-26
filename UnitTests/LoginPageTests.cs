using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Security.Cryptography.X509Certificates;
using TestingApp;

[assembly: Parallelize]
namespace UnitTests
{
    [TestClass]

    public class LoginPageTests
    {
        static LoginPage firefoxPage;
        static LoginPage edgePage;
        static FirefoxDriver firefoxDriver;
        static EdgeDriver edgeDriver;

        [TestMethod]
        public void LoginPageConstructorNullDriverThrows()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new LoginPage(null));
        }
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Called once before any MSTest test method has started (optional)
            firefoxDriver = new FirefoxDriver();
            edgeDriver = new EdgeDriver();
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            // Called once after all MSTest test methods have completed (optional)
            firefoxDriver.Quit();
            edgeDriver.Quit();
        }
        public static IEnumerable<object[]> PageData
        {
            get
            {
                return
                [
                    [firefoxPage = new LoginPage(firefoxDriver)],
                    [edgePage = new LoginPage(edgeDriver)],
                ];
            }
        }

        //[TestMethod]
        //[DynamicData(nameof(DriverData))]
        //public void LoginPageOpens(LoginPage page)
        //{
        //    string expected = "Swag Labs";
        //    try
        //    {
        //        page.Open();
        //        Assert.AreEqual(expected, driver.Title);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        driver.Quit();
        //    }
        //}

        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageLocatesInputFields(LoginPage page)
        {
            try
            {
                page.Open().Maximize().FindInputFields();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageInputNullUserThrows(LoginPage page)
        {
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().FindInputFields().InputCredentials(null, "Pass"));
            }
            catch (Exception)
            {
                throw;
            }

        }
        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageInputNullPassThrows(LoginPage page)
        {
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().FindInputFields().InputCredentials("Name", null));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageInputNullUserElementThrows(LoginPage page)
        {
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().InputCredentials("Name", "Pass"));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageInputNullPassElementThrows(LoginPage page)
        {
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().InputCredentials("Name", "Pass"));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageClearUsernameThrows(LoginPage page)
        {
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().ClearUsername());
            }
            catch (Exception)
            {
                throw;
            }
        }
        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageClearPasswordThrows(LoginPage page)
        {
            try
            {
                Assert.ThrowsException<ArgumentNullException>(() => page.Open().Maximize().ClearPassword());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageUseCase1(LoginPage page)
        {
            try
            {
                Assert.IsTrue(UseCase1(page));
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageUseCase2(LoginPage page)
        {
            try
            {
                Assert.IsTrue(UseCase2(page));
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        [DynamicData(nameof(PageData))]
        public void LoginPageUseCase3(LoginPage page)
        {
            try
            {
                Assert.IsTrue(UseCase3(page));
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        public static bool UseCase1(LoginPage page)
        {
            return page.Open().
                     Maximize().
                     FindInputFields().
                     InputCredentials("Name", "Pass").
                     ClearUsername().
                     ClearPassword().
                     Login().
                     CompareError("Username is required");
        }

        public static bool UseCase2(LoginPage page)
        {
            return page.Open().
                    Maximize().
                    FindInputFields().
                    InputCredentials("Name", "Pass").
                    ClearPassword().
                    Login().
                    CompareError("Password is required");
        }

        public static bool UseCase3(LoginPage page)
        {
            return page.Open().
                    Maximize().
                    FindInputFields().
                    InputCredentials("standard_user", "secret_sauce").
                    Login().
                    FindTitle();
        }
    }
}
