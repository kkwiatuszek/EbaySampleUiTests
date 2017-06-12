using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Helpers
{
    public static class Sync
    {
        public static T WaitFor<T>(int timeInSeconds, Func<IWebDriver, T> condition)
        {
            IWait<IWebDriver> wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(timeInSeconds));
            return wait.Until(condition);
        }

        public static void WaitUntilPageIsCompletelyLoaded()
        {
            WaitFor(10, _ => ((IJavaScriptExecutor)Browser.Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void Wait(int seconds)
        {
            Browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

    }
}
