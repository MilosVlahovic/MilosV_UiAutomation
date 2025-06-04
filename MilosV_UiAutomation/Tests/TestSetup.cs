using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MilosV_UiAutomation.Tests
{
    public class TestSetup
    {
        protected IWebDriver driver;

        [SetUp]
        public void StartBrowserSession()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowserSession()
        {
            driver.Quit();
        }
    }
}