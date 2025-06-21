namespace TestingApp
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebDriver driver = new FirefoxDriver();
            try
            {
                LoginPage page = new LoginPage(driver);
                UseCase3(page);
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
