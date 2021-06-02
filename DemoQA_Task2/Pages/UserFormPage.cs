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
        IWebElement userGender(int gender) => Driver.FindElement(By.XPath($"//label[@for='gender-radio-{gender}']"));
        IWebElement userEmail => Driver.FindElement(By.Id("userEmail"));
        IWebElement userNumber => Driver.FindElement(By.Id("userNumber"));
        IWebElement subjectInput => Driver.FindElement(By.Id("subjectsInput"));
        IReadOnlyCollection<IWebElement> userHobbies => Driver.FindElements(By.CssSelector("label[for^='hobbies-checkbox']"));
        IWebElement currentAddress => Driver.FindElement(By.Id("currentAddress"));
        IWebElement userState => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("react-select-3-input")));
        IWebElement userCity => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("react-select-4-input")));
        IWebElement dateOfBirthInput => Driver.FindElement(By.Id("dateOfBirthInput"));
        
        private static void StateAndCity(string data, IWebElement element)
        {
            element.SendKeys(data + Keys.Enter);
        }
        private static void EnterSubject(string[] subjects, IWebElement element)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                element.SendKeys(subjects[i]);
                element.SendKeys(Keys.Enter);
            }
        }
        private static void EnterHobby(int[] quantity, IReadOnlyCollection<IWebElement> element)
        {
            for (int i = 0; i < quantity.Length; i++)
            {
                element.ElementAt(quantity[i]).Click();
            }
        }

        public UserFormPage Register(User user)
        {
            //Elements are in such order due to the fact, that only name, lastname, phone and gender are needed
            //to submit form. For Subjects, State and City Key.Enter is used, so all form will be submitted even without
            //all fields fulfilled. So, the Execption will be generated and test will be failed. Instead of Submit button
            //phonenumber + Key.Enter is used in order to submit form.

            currentAddress.SendKeys(user.Address);

            StateAndCity(user.StateAndCity[0], userState);
            StateAndCity(user.StateAndCity[1], userCity);
            EnterSubject(user.Subject, subjectInput);
            EnterHobby(user.Hobbies, userHobbies);

            dateOfBirthInput.SendKeys(Keys.Control + "A");
            dateOfBirthInput.SendKeys(user.DateOfBirth + Keys.Enter);

            firstName.SendKeys(user.Name);
            lastName.SendKeys(user.LastName);
            userEmail.SendKeys(user.Email);

            userGender(user.Gender).Click();

            userNumber.SendKeys(user.Phone + Keys.Enter);

            return new UserFormPage(Driver);
        }
    }
}
