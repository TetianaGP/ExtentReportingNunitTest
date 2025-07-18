using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExtentReporting2
{
    public class Tests : TestBase
    {
        IWebElement LoginLink => driver.FindElement(By.XPath("//a[@data-testid='navbar-login']"));
        IWebElement LoginHeader => driver.FindElement(By.XPath("//h1[text()='Login']"));

        [Test]
        public void Report_Test()
        {
            ExtentReporting.LogInfo("Test started...");
            LoginLink.Click();
            Assert.That(LoginHeader.Displayed);
        }

        [Test]
        public void Report_Test_Fail()
        {
            ExtentReporting.LogInfo("Test started...");
            LoginLink.Click();
            Assert.That(!LoginHeader.Displayed);
        }
       
    }
}
