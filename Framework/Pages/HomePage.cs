using System.Collections.Generic;
using System.Linq;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    public class HomePage
    {
        [FindsBy(How = How.CssSelector, Using = ".hl-cat-nav__container")]
        private IWebElement _menu;

        [FindsBy(How = How.CssSelector, Using = ".hl-cat-nav__js-tab")]
        private IList<IWebElement> _menuTabs;

        [FindsBy(How = How.CssSelector, Using = ".hl-cat-nav__js-tab.hl-cat-nav__js-show .hl-cat-nav__flyout")]
        private IWebElement _subcategoriesList;

        [FindsBy(How = How.CssSelector, Using = ".hl-cat-nav__js-tab.hl-cat-nav__js-show")]
        private IWebElement _activeCategory;

        [FindsBy(How = How.CssSelector, Using = ".hl-infinite-carousel__main .icon-chevron-left")]
        private IWebElement _carouselLeftArrow;

        [FindsBy(How = How.CssSelector, Using = ".hl-infinite-carousel__main .icon-chevron-right")]
        private IWebElement _carouselRightArrow;

        [FindsBy(How = How.CssSelector, Using = ".hl-banner-carousel__cell[aria-hidden='false'] .hl-image")]
        private IWebElement _


        public void ClickCategory(string categoryName)
        {
            _menuTabs.First(i => i.Text == categoryName).Click();
        }

        public void HoverCategory(string categoryName)
        {
            var element = _menuTabs.First(i => i.Text == categoryName);

            Actions hover = new Actions(Browser.Driver);
            hover.MoveToElement(element).Perform();
        }

        public bool IsListOfSubcategoriesDisplayed()
        {
            return _subcategoriesList.IsVisible();
        }

        public bool IsCategoryDisplayed(string categoryName)
        {
            return _menuTabs.Any(i => i.Text == categoryName);
        }

        public void ClickArrow(IWebElement arrow)
        {
            arrow.Click();
        }

        public void ClickRightArrow()
        {
            ClickArrow(_carouselRightArrow);
        }

        public void ClickLeftArrow()
        {
            ClickArrow(_carouselLeftArrow);
        }

        public string GetUrlOfImage()
        {
            
        }
    }
}
