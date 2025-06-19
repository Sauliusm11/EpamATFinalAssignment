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
                driver.Manage().Window.Maximize();

                IWebElement userName = driver.FindElement(By.XPath("//input[@placeholder='Username']"));
                IWebElement password = driver.FindElement(By.XPath("//input[@placeholder='Password']"));

                userName.SendKeys("Name");
                password.SendKeys("Pass");

                userName.Clear();
                password.Clear();

                IWebElement loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
                loginButton.Click();

                IWebElement errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']"));
                string expectedError = "Username is required";
                if (errorMessage.Text.Contains(expectedError)) 
                {
                    Console.WriteLine("Sucess!");
                }
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
