using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FoodyAppTestProject_Exam.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement HomeLink => driver.FindElement(By.XPath("//a[@class='navbar-brand']"));
        public IWebElement MyProfileLink => driver.FindElement(By.XPath("//a[@href='Profile']"));
        public IWebElement AddFoodLink => driver.FindElement(By.XPath("//a[@class='nav-link'][text()='Add Food']"));
        public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@class='nav-link'][text()='Logout']"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//a[@class='nav-link'][text()='Log In']"));
    }
}
