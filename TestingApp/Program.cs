using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace TestingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebDriver driver = new FirefoxDriver();
            try
            {
                UseCase3(driver);
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

        static void UseCase1(WebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Open().
                Maximize().
                FindInputFields().
                InputCredentials("Name", "Pass").
                ClearUsername().
                ClearPassword().
                Login().
                CompareError("Username is required");
        }
        static void UseCase2(WebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Open().
                Maximize().
                FindInputFields().
                InputCredentials("Name", "Pass").
                ClearPassword().
                Login().
                CompareError("Password is required");
        }

        static void UseCase3(WebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Open().
                Maximize().
                FindInputFields().
                InputCredentials("standard_user", "secret_sauce").
                Login().
                FindTitle();
        }
    }
}
