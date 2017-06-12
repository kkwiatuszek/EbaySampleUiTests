using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);

            return page;
        }

        public static HomePage HomePage => GetPage<HomePage>();
    }
}