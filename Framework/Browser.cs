using System;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework
{
    public class Browser
    {
        public static IWebDriver Driver { get; private set; }

        public static void TakeErrorScreenshot(string title)
        {
            var timestamp = DateTime.Now.ToString("dd-MMM-yyyy hh.mm.ss");
            var currentDir = Environment.CurrentDirectory;
            const string folderName = "\\ErrorScreenshots";

            Directory.CreateDirectory(currentDir + folderName);

            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            screenshot.SaveAsFile(currentDir + folderName + "\\" + title + " - " + timestamp + ".png", ImageFormat.Png);
        }

        public static void Initialize()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(6));
        }

        public static void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static bool IsAlertPresent()
        {
            try
            {
                Driver.SwitchTo().Alert();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                return false;
            }
        }

        public static void Quit()
        {
            if (Driver == null)
                return;

            Driver.Quit();

            if (IsAlertPresent())
                Driver.SwitchTo().Alert().Accept();

            Driver = null;
        }

    }
}
