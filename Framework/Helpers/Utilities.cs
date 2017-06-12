using System;
using OpenQA.Selenium;

namespace Framework.Helpers
{
    public static class Utilities
    {
        public static bool Exists(this IWebElement element)
        {
            try
            {
                return element.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsVisible(this IWebElement element)
        {
            try
            {
                return Exists(element) && element.Displayed;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
        }
    }
}
