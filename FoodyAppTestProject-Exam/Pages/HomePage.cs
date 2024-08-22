using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyAppTestProject_Exam.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl;

        public ReadOnlyCollection<IWebElement> FoodRevues => driver.FindElements(By.XPath("//section[@id='scroll']"));
        public IWebElement EditButtonLastFood => FoodRevues.Last().FindElement(By.XPath(".//a[contains(@href,'/Food/Edit')]"));
        public IWebElement DeleteButtonLastFood => FoodRevues.Last().FindElement(By.XPath(".//a[contains(@href,'/Food/Delete')]"));
        public IWebElement NameLastFood => FoodRevues.Last().FindElement(By.XPath(".//h2[@class='display-4']"));
        public IWebElement DescriptionLastFood => FoodRevues.Last().FindElement(By.XPath(".//p[@class='flex-lg-wrap']"));
        public IWebElement searchField => driver.FindElement(By.XPath("//input[@name='keyword']"));
        public IWebElement searchButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
