using OpenQA.Selenium.Interactions;

namespace FoodyAppTestProject_Exam.Tests
{
    public class FoodyAppTests : BaseTest
    {
        public string lastAddedFoodName;
        public string lastAddedFoodDescription;

        [Test, Order(1)]
        public void AddFoodWithInvalidData()
        {
            addFoodPage.OpenPage();
            addFoodPage.AddFood("", "", "");
            Assert.That(driver.Url, Is.EqualTo(addFoodPage.Url), "URL is not correct.");
            addFoodPage.AssertErrorMessages();
        }

        [Test, Order(2)]
        public void AddFoodWithRandomValidData()
        {
            lastAddedFoodName = "Food " + GenerateRandomString(10);
            lastAddedFoodDescription = "Description " + GenerateRandomString(40);
            addFoodPage.OpenPage();
            addFoodPage.AddFood(lastAddedFoodName, lastAddedFoodDescription, "");
            Assert.That(driver.Url, Is.EqualTo(homePage.Url), "URL is not correct.");
            Assert.That(homePage.NameLastFood.Text.Trim(), Is.EqualTo(lastAddedFoodName), "Food name do not match.");
        }

        [Test, Order(3)]

        public void EditLastAddedFoodName()
        {
            homePage.OpenPage();
            actions.ScrollToElement(homePage.EditButtonLastFood).Perform();
            homePage.EditButtonLastFood.Click();

            string editedName = "Edited name: " + lastAddedFoodName;

            editFoodPage.FoodNameInput.Clear();
            editFoodPage.FoodNameInput.SendKeys(editedName);
            editFoodPage.AddButton.Click();

            
            Assert.That(homePage.NameLastFood.Text.Trim(), Is.EqualTo(lastAddedFoodName), "Food name do not match!");
            Console.WriteLine("Food name change won't be possible due to incomplete functionality");
        }

        [Test, Order(4)]

        public void SearchForAddedFood()
        {
            homePage.OpenPage();
            homePage.searchField.SendKeys(lastAddedFoodName);
            homePage.searchButton.Click();


            Assert.That(searchPage.FoodRevuesCount.Count(), Is.EqualTo(1), "Search does not return only one result.");
            Assert.That(searchPage.FoodName.Text, Is.EqualTo(lastAddedFoodName), "Food name do not match");
        }

        [Test, Order(5)]

        public void DeleteLastAddedFood()
        {            
            homePage.OpenPage();
            var initialFoodRevuesCount = homePage.FoodRevuesCount.Count();
            actions.ScrollToElement(homePage.DeleteButtonLastFood).Perform();                                   
            homePage.DeleteButtonLastFood.Click();
            var finalFoodRevuesCount = homePage.FoodRevuesCount.Count();

            if (finalFoodRevuesCount < 2)
            {
                Assert.That(finalFoodRevuesCount, Is.EqualTo(initialFoodRevuesCount), "Food revue was not deleted.");
            }
            else
            {
                Assert.That(finalFoodRevuesCount, Is.EqualTo(initialFoodRevuesCount-1), "Food revue was not deleted.");
            }

            Assert.That(homePage.NameLastFood.Text, Is.Not.EqualTo(lastAddedFoodName), "Last food names are matching.");
        }

        [Test, Order(6)]

        public void SearchForDeletedFood()
        {
            homePage.OpenPage();
            homePage.searchField.SendKeys(lastAddedFoodName);
            homePage.searchButton.Click();


            Assert.That(searchPage.NoFoodsMessage.Text, Is.EqualTo("There are no foods :("), "Error message is not displayed.");
            Assert.That(searchPage.AddButton.Displayed, Is.True,  "Food name do not match");
        }
    }
}