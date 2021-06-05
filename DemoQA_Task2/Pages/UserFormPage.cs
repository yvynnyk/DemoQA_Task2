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
        WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5)); 
        IWebElement FirstName => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("firstName")));
        IWebElement LastName => Driver.FindElement(By.Id("lastName"));
        IWebElement UserGender(int gender) => Driver.FindElement(By.XPath($"//label[@for='gender-radio-{gender}']"));
        IWebElement UserEmail => Driver.FindElement(By.Id("userEmail"));
        IWebElement UserNumber => Driver.FindElement(By.Id("userNumber"));
        IWebElement SubjectInput => Driver.FindElement(By.Id("subjectsInput"));
        IReadOnlyCollection<IWebElement> userHobbies => Driver.FindElements(By.CssSelector("label[for^='hobbies-checkbox']"));
        IWebElement CurrentAddress => Driver.FindElement(By.Id("currentAddress"));
        IWebElement UserState => Driver.FindElement(By.Id("react-select-3-input"));
        IWebElement UserCity => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("react-select-4-input")));
        IWebElement DateOfBirthInput => Driver.FindElement(By.Id("dateOfBirthInput"));
        IWebElement ButtonSubmit => Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("submit")));
        private static void EnterState(string[] stateandcity, IWebElement State)
        {
            State.SendKeys(stateandcity[0] + Keys.Tab);
        }
        private static void EnterCity(string[] stateandcity, IWebElement City)
        {
            City.SendKeys(stateandcity[1] + Keys.Tab);
        }
        private static void EnterSubject(string[] subjects, IWebElement Subject)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                Subject.SendKeys(subjects[i] + Keys.Tab);
            }
        }
        private static void EnterHobby(int[] quantity, IReadOnlyCollection<IWebElement> Elements)
        {
            for (int i = 0; i < quantity.Length; i++)
            {
                Elements.ElementAt(quantity[i]).Click();
            }
        }
        private static void EnterBirthDay(IWebElement birthdayinput, string date)
        {
            birthdayinput.SendKeys(Keys.Control + "A");
            birthdayinput.SendKeys(date + Keys.Enter);
        }
        public UserFormPage Register(User user)
        {
            FirstName.SendKeys(user.Name);
            LastName.SendKeys(user.LastName);
            UserEmail.SendKeys(user.Email);
            UserGender(user.Gender).Click();
            UserNumber.SendKeys(user.Phone);
            EnterBirthDay(DateOfBirthInput, user.DateOfBirth);
            EnterSubject(user.Subject, SubjectInput);
            EnterHobby(user.Hobbies, userHobbies);
            CurrentAddress.SendKeys(user.Address);
            EnterState(user.StateAndCity, UserState);
            EnterCity(user.StateAndCity, UserCity);
            
            ButtonSubmit.Click();

            return new UserFormPage(Driver);
        }
    }
}
