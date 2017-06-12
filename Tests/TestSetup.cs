using Framework;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public static class TestSetup
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            if (Browser.Driver == null)
                Browser.Initialize();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
                Browser.TakeErrorScreenshot(ScenarioContext.Current.ScenarioInfo.Title);

            Browser.Quit();
        }
    }
}
