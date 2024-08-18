using OpenQA.Selenium;

namespace FoodyAppTestProject_Exam.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "User/Login";

        public IWebElement UsernameInput => driver.FindElement(By.XPath("//input[@name='Username']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@name='Password']"));
        public IWebElement SignInButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));

        public void Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            SignInButton.Click();
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

    }
}
