using OpenQA.Selenium;

namespace TestingApp
{
    public class MainPage
    {
        protected IWebDriver driver;
        public MainPage(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public bool CompareError(string expectedError)
        {
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
