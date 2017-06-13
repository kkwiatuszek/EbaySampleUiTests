using Framework;
using Framework.Helpers;
using Framework.Pages;
using Shouldly;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    [Binding]
    public class HomePageModulesSteps
    {
        public static string defaultImage { get; set; }

        [Given(@"I have navigated to home page of ebay")]
        public void GivenIHaveNavigatedToHomePageOfEbay()
        {
            Browser.NavigateTo("http://www.ebay.co.uk/");
            Sync.WaitUntilPageIsCompletelyLoaded();
            defaultImage = Pages.HomePage.GetUrlOfImage();
        }
        
        [When(@"I hover ""(.*)"" category")]
        public void WhenIHoverCategory(string categoryName)
        {
            Pages.HomePage.HoverCategory(categoryName);
            Sync.Wait(5);
        }
        
        [When(@"I click ""(.*)"" category")]
        public void WhenIClickCategory(string categoryName)
        {
            Pages.HomePage.ClickCategory(categoryName);
        }

        [When(@"I click left arrow on carousel")]
        public void WhenIClickLeftArrowOnCarousel()
        {
            Pages.HomePage.ClickLeftArrow();
        }
        
        [When(@"I click right arrow on carousel")]
        public void WhenIClickRightArrowOnCarousel()
        {
            Pages.HomePage.ClickRightArrow();
        }
        
        [Then(@"menu tab should show correct (.*)")]
        public void ThenMenuTabShouldShowCorrect(string categoryName)
        {
            Pages.HomePage.IsCategoryDisplayed(categoryName).ShouldBe(true);
        }

        [Then(@"list of subcategories is displayed")]
        public void ThenListOfSubcategoriesIsDisplayed()
        {
            Pages.HomePage.IsListOfSubcategoriesDisplayed().ShouldBe(true);
        }

        [Then(@"page redirects to  ""(.*)"" category page")]
        public void ThenPageRedirectsToCategoryPage(string categoryName)
        {
            Browser.Driver.Url.ShouldContain(categoryName);
        }
        
        [Then(@"image changes")]
        public void ThenImageChanges()
        {
            Pages.HomePage.GetUrlOfImage().ShouldNotBe(defaultImage);
        }
    }
}
