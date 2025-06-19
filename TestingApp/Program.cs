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
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                UseCase1(driver);
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
            LoginPage loginPage = new LoginPage(new FirefoxDriver());
            loginPage.Maximize().
                FindInputFields().
                InputCredentials("Name", "Pass").
                ClearUsername().
                ClearPassword().
                Login().
                CompareError("Username is required");
        }
        static void UseCase2(WebDriver driver)
        {
            LoginPage loginPage = new LoginPage(new FirefoxDriver());
            loginPage.Maximize().
                FindInputFields().
                InputCredentials("Name", "Pass").
                ClearPassword().
                Login().
                CompareError("Password is required");
        }

    }
}
