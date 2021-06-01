using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQA_Task2
{
    class BaseTest
    {
        protected IWebDriver Driver;
        [SetUp]
        public void Init()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}
