using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyAppTestProject_Exam.Pages
{
    public class AddFoodPage : BasePage
    {
        public AddFoodPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "Food/Add";

        public IWebElement FoodNameInput => driver.FindElement(By.XPath("//input[@name='Name']"));        
        public IWebElement DescriptionInput => driver.FindElement(By.XPath("//input[@name='Description']"));
        public IWebElement ImageUrlInput => driver.FindElement(By.XPath("//input[@name='Url']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
        public IWebElement MainErrorMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));

        public IWebElement NameErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[0];
        public IWebElement DescriptionErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[1];

        public void AddFood(string foodName, string description, string imageUrl)
        {
            FoodNameInput.SendKeys(foodName);
            DescriptionInput.SendKeys(description);
            ImageUrlInput.SendKeys(imageUrl);
            AddButton.Click();
        }
        

        public void AssertErrorMessages()
        {
            Assert.True(MainErrorMessage.Text.Equals("Unable to add this food revue!"), "Main error message is not as expected.");
            Assert.True(NameErrorMessage.Text.Equals("The Name field is required."), "Name error message is not as expected.");
            Assert.True(DescriptionErrorMessage.Text.Equals("The Description field is required."), "Description error message is not as expected.");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
