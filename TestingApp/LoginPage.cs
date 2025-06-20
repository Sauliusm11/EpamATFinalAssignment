using OpenQA.Selenium;

namespace TestingApp
{
    public class LoginPage
    {
        private static string Url { get; } = "https://www.saucedemo.com/";

        private readonly IWebDriver driver;

        IWebElement usernameElement;
        IWebElement passwordElement;

        public LoginPage(IWebDriver driver)
        {
            ArgumentNullException.ThrowIfNull(driver, nameof(driver));
            this.driver = driver;
        }

        public LoginPage Open()
        {
            driver.Navigate().GoToUrl(Url);
            return this;
        }

        public LoginPage Maximize() 
        {
            driver.Manage().Window.Maximize();
            return this;
        }

        public LoginPage FindInputFields()
        {
            usernameElement = driver.FindElement(By.XPath("//input[@placeholder='Username']"));
            passwordElement = driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            return this;
        }

        public LoginPage InputCredentials(string username, string password) 
        {
            usernameElement.SendKeys(username);
            passwordElement.SendKeys(password);
            return this;
        }

        public LoginPage ClearUsername()
        {
            usernameElement.Clear();
            return this;
        }

        public LoginPage ClearPassword() 
        {
            passwordElement.Clear();
            return this;
        }
        public MainPage Login() 
        {
            IWebElement loginButton = driver.FindElement(By.XPath("//input[@id='login-button']"));
            loginButton.Click();
            return new MainPage(driver);
        }
    }
}
