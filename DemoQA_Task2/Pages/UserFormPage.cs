using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoQA_Task2
{
    public class UserFormPage : BasePage
    {
        public UserFormPage(IWebDriver driver) : base(driver)
        {
        }
        WebDriverWait wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5)); 
        IWebElement firstName => Driver.FindElement(By.Id("firstName"));
        IWebElement lastName => Driver.FindElement(By.Id("lastName"));
        IWebElement userEmail => Driver.FindElement(By.Id("userEmail"));
        IWebElement userNumber => Driver.FindElement(By.Id("userNumber"));
        IWebElement subjectInput => Driver.FindElement(By.Id("subjectsInput"));
        IReadOnlyCollection<IWebElement> userHobbies => Driver.FindElements(By.CssSelector("label[for^='hobbies-checkbox']"));
        IWebElement currentAddress => Driver.FindElement(By.Id("currentAddress"));
        IWebElement userState => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("react-select-3-input")));
        IWebElement userCity => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("react-select-4-input")));
        IWebElement dateOfBirthInput => Driver.FindElement(By.Id("dateOfBirthInput"));
        IWebElement buttonSubmit => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("submit")));
        public UserFormPage Register(User user)
        {
            //Elements are in such order due to the fact, that only name, lastname, phone and gender are needed
            //to submit form. For Subjects, State and City Key.Enter is used, so all form will be submitted even without
            //all fields fulfilled. So, the Execption will be generated and test will be failed. Instead of Submit button
            //phonenumber + Key.Enter is used in order to submit form.

            currentAddress.SendKeys(user.Address);

            var StateAndCity = User.StateAndCity;
            userState.SendKeys(StateAndCity[0] + Keys.Enter);
            userCity.SendKeys(StateAndCity[1] + Keys.Enter);

            var subjects = User.Subject;
            for (int i = 0; i < subjects.Length; i++)
            {
                subjectInput.SendKeys(subjects[i]);
                subjectInput.SendKeys(Keys.Enter);
            }

            var quantity = User.Hobby;
            for (int i = 0; i < quantity.Length; i++)
            {
                userHobbies.ElementAt(quantity[i]).Click();
            }

            dateOfBirthInput.SendKeys(Keys.Control + "A");
            dateOfBirthInput.SendKeys(user.DateOfBirth + Keys.Enter);

            firstName.SendKeys(user.Name);
            lastName.SendKeys(user.LastName);
            userEmail.SendKeys(user.Email);
            Driver.FindElement(By.XPath($"//label[@for='gender-radio-{user.Gender}']")).Click();

            userNumber.SendKeys(user.Phone + Keys.Enter);

            return new UserFormPage(Driver);
        }
    }
}
