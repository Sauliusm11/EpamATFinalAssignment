namespace TestingApp
{
    using OpenQA.Selenium;

    public class LoginPage
    {
        private readonly IWebDriver driver;

        private IWebElement usernameElement;
        private IWebElement passwordElement;

        public LoginPage(IWebDriver driver)
        {
            ArgumentNullException.ThrowIfNull(driver, nameof(driver));
            this.driver = driver;
        }

        private static string Url { get; } = "https://www.saucedemo.com/";

        public LoginPage Open()
        {
            this.driver.Navigate().GoToUrl(Url);
            return this;
        }

        public LoginPage Maximize()
        {
            this.driver.Manage().Window.Maximize();
            return this;
        }

        public LoginPage FindInputFields()
        {
            this.usernameElement = this.driver.FindElement(By.XPath("//input[@placeholder='Username']"));
            this.passwordElement = this.driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            return this;
        }

        public LoginPage InputCredentials(string username, string password)
        {
            ArgumentNullException.ThrowIfNull(username, nameof(username));
            ArgumentNullException.ThrowIfNull(password, nameof(password));
            ArgumentNullException.ThrowIfNull(this.usernameElement, nameof(this.usernameElement));
            ArgumentNullException.ThrowIfNull(this.passwordElement, nameof(this.passwordElement));
            this.usernameElement.SendKeys(username);
            this.passwordElement.SendKeys(password);
            return this;
        }

        public LoginPage ClearUsername()
        {
            ArgumentNullException.ThrowIfNull(this.usernameElement, nameof(this.usernameElement));
            this.usernameElement.Clear();
            return this;
        }

        public LoginPage ClearPassword()
        {
            ArgumentNullException.ThrowIfNull(this.passwordElement, nameof(this.passwordElement));
            this.passwordElement.Clear();
            return this;
        }

        public MainPage Login()
        {
            IWebElement loginButton = this.driver.FindElement(By.XPath("//input[@id='login-button']"));
            loginButton.Click();
            return new MainPage(this.driver);
        }
    }
}
