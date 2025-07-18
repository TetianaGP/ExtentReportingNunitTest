using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExtentReporting2
{
    public class TestBase
    {
        protected IWebDriver driver;
        private readonly string url = "https://commitquality.com";

        [SetUp]
        public void Setup()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void Teardown()
        {
            EndTest();
            ExtentReporting.EndReporting();
            driver.Quit();
            driver.Dispose();

        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var msg = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Passed:
                    ExtentReporting.LogPass("Test Passed");
                    break;
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test Failed: {msg}");
                    SaveScreenshot();
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo("Test Skipped");
                    break;
            }
            ExtentReporting.LogInfo($"Test completed at {DateTime.Now}");
            SaveScreenshot();

        }

        private void SaveScreenshot()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var imagePath = Directory.CreateDirectory(ExtentReporting.reportPath + "Screenshots") +
                $"/screenshot-{DateTime.Now:yyyyMMdd_HHmmss}.png";
            screenshot.SaveAsFile(imagePath);
            ExtentReporting.LogScreenshot("Screenshot of failure or ending test", imagePath);
        }
    }
}
