using OpenQA.Selenium;

namespace DemoQA_Task2
{
    public class BasePage
    {
        public IWebDriver Driver;
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }
    }
}
