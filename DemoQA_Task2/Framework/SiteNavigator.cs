using System.Configuration;
using OpenQA.Selenium;

namespace DemoQA_Task2
{
    public class SiteNavigator
    {
        public static UserFormPage NavigateToUserFormPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            return new UserFormPage(driver);
        }
    }
}
