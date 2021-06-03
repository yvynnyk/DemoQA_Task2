using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Task2
{
    public class User
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public int Gender { get; private set; }
        public string Phone { get; private set; }
        public string DateOfBirth { get; private set; }
        public string[] StateAndCity { get; private set; }
        private static string [] GetStateAndCity ()
        { 
            
                string[] StateAndCity = new string[2];
                string[] State = { "NCR", "Uttar Pradesh", "Haryana", "Rajasthan" };
                int numberState = RandomNumber(1, 5);
                StateAndCity[0] = State[numberState - 1];

                string[] CityNCR = { "Delhi", "Gurgaon", "Noida" };
                string[] CityUttah = { "Agra", "Lucknow", "Merrut" };
                string[] CityHaryana = { "Karnal", "Panipat" };
                string[] CityRajastan = { "Jaipur", "Jaiselmer" };

                if (numberState == 1)
                {
                    int numberCity = RandomNumber(1, 4);
                    StateAndCity[1] = CityNCR[numberCity - 1];
                }
                else if (numberState == 2)
                {
                    int numberCity = RandomNumber(1, 4);
                    StateAndCity[1] = CityUttah[numberCity - 1];
                }
                else if (numberState == 3)
                {
                    int numberCity = RandomNumber(1, 3);
                    StateAndCity[1] = CityHaryana[numberCity - 1];
                }
                else 
                {
                    int numberCity = RandomNumber(1, 3);
                    StateAndCity[1] = CityRajastan[numberCity - 1];
                }

                return StateAndCity;
             
        }
        public string [] Subject { get; private set; }
        private static string[] GetSubject ()
        {
                int number = RandomNumber(0, 5);
                if (number == 1)
                {
                    return new string [] { "Maths", "Accounting", "Arts", "Social Studies" };
                }
                else if (number == 2)
                {
                    return new string[] { "Maths", "Arts", "Social Studies" };
                }
                else if (number == 3)
                {
                    return new string[] { "Arts", "Social Studies" };
                }
                else if (number == 4)
                {
                    return new string[] { "Maths", "Social Studies" };
                }
                else
                {
                    return new string[] { String.Empty };
                }
    
        }
        public string Address { get; private set; }
        public int[] Hobbies { get; private set; }
        private static int[] GetHobby ()
        {
                int[] quantity = new int[RandomNumber(1, 4)];
                int number = RandomNumber(1, 4);
                if (quantity.Length == 1)
                {
                    quantity[0] = RandomNumber(0, 3);
                }
                else if (quantity.Length == 3)
                {
                    quantity[0] = 0;
                    quantity[1] = 1;
                    quantity[2] = 2;
                }
                else if (quantity.Length == 2 && number == 1)
                {
                    quantity[0] = 0;
                    quantity[1] = 1;
                }
                else if (quantity.Length == 2 && number == 2)
                {
                    quantity[0] = 0;
                    quantity[1] = 2;
                }
                else if (quantity.Length == 2 && number == 3)
                {
                    quantity[0] = 1;
                    quantity[1] = 2;
                }

                return quantity;
        }

        private static int Year
        {
            get
            {
                return RandomNumber(1900, DateTime.Now.Year);
            }
        }
        private static int Month 
        {
            get
            {
                return RandomNumber(1, 13);
            }
        }
        private static int Day
        {
            get
            {
                if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                {
                    return RandomNumber(1, 32);
                }
                else if ( Month == 4 || Month == 6 || Month == 9 || Month == 11)
                {
                    return RandomNumber(1, 31);
                }
                else
                {
                    return RandomNumber(1, 29);
                }
            }
        }

        private static string GetPhoneNumber()
        {
            string[] phone = new string[10];
            for (int i = 0; i < phone.Length; i++)
            {
                phone[i] = RandomNumber(0, 10).ToString();
            }
            return String.Join("", phone);
        }

        private static DateTime Birthday
        {
            get
            {
                return new DateTime(Year, Month, Day);
            }
        }

        public static User GetUserInfo()
        {
            return new User
            {
                Name = "John",
                LastName = "Johnson",
                Email = "john.johnson@email.com",
                Gender = RandomNumber(1, 4),
                Phone = GetPhoneNumber(),
                Hobbies = GetHobby(),
                StateAndCity = GetStateAndCity(),
                Subject = GetSubject(),
                DateOfBirth = Birthday.ToString("dd/MMM/yyyy", CultureInfo.CreateSpecificCulture("en-US")),
                Address = "New Street, 01",
            };
        }
        
        private static int RandomNumber(int min, int max)
        {
            Random _random = new Random();
            return _random.Next(min, max);
        }
    }
}
