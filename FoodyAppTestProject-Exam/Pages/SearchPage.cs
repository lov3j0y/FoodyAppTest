using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyAppTestProject_Exam.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
            
        }

        public ReadOnlyCollection<IWebElement> FoodRevues => driver.FindElements(By.XPath("//div[@class='p-5']"));
        public ReadOnlyCollection<IWebElement> FoodRevuesCount => driver.FindElements(By.XPath("//div[@class='p-5']//h2"));
        public IWebElement EditButton => FoodRevues.Last().FindElement(By.XPath(".//a[contains(@href,'/Food/Edit')]"));
        public IWebElement DeleteButton => FoodRevues.Last().FindElement(By.XPath(".//a[contains(@href,'/Food/Delete')]"));
        public IWebElement FoodName => FoodRevues.Last().FindElement(By.XPath(".//h2[@class='display-4']"));
        public IWebElement FoodDescription => FoodRevues.Last().FindElement(By.XPath(".//p[@class='flex-lg-wrap']"));
        public IWebElement NoFoodsMessage => driver.FindElement(By.XPath("//div[@class='p-5']//h2"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']"));



    }
}
