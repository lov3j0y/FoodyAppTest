using FoodyAppTestProject_Exam.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace FoodyAppTestProject_Exam.Tests
{
    public class BaseTest
    {
        public WebDriver driver;

        public LoginPage loginPage;

        public AddFoodPage addFoodPage;

        public HomePage homePage;

        public EditFoodPage editFoodPage;

        public Actions actions;

        public SearchPage searchPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            
            loginPage = new LoginPage(driver);
            addFoodPage = new AddFoodPage(driver);
            homePage = new HomePage(driver);
            editFoodPage = new EditFoodPage(driver);
            actions = new Actions(driver);
            searchPage = new SearchPage(driver);



            loginPage.OpenPage();
            loginPage.Login("examDemo", "123456");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "abcdasdsdsadjkdlksadsajk";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
