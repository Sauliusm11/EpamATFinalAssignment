using OpenQA.Selenium;

namespace TestingApp
{
    public class MainPage
    {
        protected IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            ArgumentNullException.ThrowIfNull(driver, nameof(driver));
            this.driver = driver;
        }

        public bool CompareError(string expectedError)
        {
            ArgumentNullException.ThrowIfNull(expectedError, nameof(expectedError));
            IWebElement errorMessage = driver.FindElement(By.XPath("//h3[@data-test='error']"));
            return errorMessage.Text.Contains(expectedError);
        }

        public bool FindTitle()
        {
            IWebElement appLogo = driver.FindElement(By.XPath("//div[@class='app_logo']"));
            string expectedText = "Swag Labs";
            return appLogo.Text.Contains(expectedText);
        }
    }
}
