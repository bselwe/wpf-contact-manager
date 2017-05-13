using Contact_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager.Helpers
{
    public class RandomContactsGenerator
    {
        private static string[] maleNames = { "John", "George", "Michael", "Edward" };
        private static string[] femaleNames = {"Margareth", "Elisabeth", "Katherine", "Diana"};
        private static string[] lastNames = {"Nord", "Smith", "Hammer", "Abrams"};
        private static string[] cities = { "New York", "Chicago", "Los Angeles", "San Diego", "San Francisco", "Filadelfia"};

        public IList<Contact> GenerateContacts(int n)
        {
            var contacts = new List<Contact>();
            var random = new Random();

            for (int i = 0; i < n; i++)
            {
                string name;
                string lastName = lastNames[random.Next(lastNames.Length)];
                Sex sex = random.Next(2) == 0 ? Sex.Male : Sex.Female;
                string city = cities[random.Next(cities.Length)];

                if (sex == Sex.Male)
                    name = maleNames[random.Next(maleNames.Length)];
                else
                    name = femaleNames[random.Next(femaleNames.Length)];

                contacts.Add(new Contact(name, lastName, DateTime.Now, sex, GeneratePhoneNumber(), city, null));
            }

            return contacts;
        }

        private string GeneratePhoneNumber()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var s = String.Empty;

            for (int i = 0; i < 9; i++)
                s = String.Concat(s, random.Next(0, 9).ToString());

            return s;
        }
    }
}
