using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQA_Task2
{
    [TestFixture]
    class RegistrationTest : BaseTest
    {
        private User _user;
        private string successLoginMessage;
        [SetUp]
        protected void Initialize()
        {
            _user = User.GetUserInfo();
            successLoginMessage = "Thanks for submitting the form";
        }
        [Test]
        public void SubmitNewUser()
        {
            UserFormPage userPage = SiteNavigator.NavigateToUserFormPage(Driver).Register(_user);
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            IWebElement confirmationMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("example-modal-sizes-title-lg")));
            Assert.That(successLoginMessage, Is.EqualTo(confirmationMessage.Text), $"Message '{successLoginMessage}' was not displayed. Registration failed.");
        }
    }
}
