using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using System.Xml.Serialization;

namespace Contact_Manager.Models
{
    // ObservableObject not needed since UpdateSourceTrigger is set to LostFocus (default)
    // Set UpdateSourceTrigger to PropertyChanged for instant model update

    public class Contact : ObservableObject
    {
        [XmlIgnore]
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        [XmlIgnore]
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        [XmlIgnore]
        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set { SetProperty(ref birthday, value); }
        }

        [XmlIgnore]
        private Sex sex;
        public Sex Sex
        {
            get { return sex; }
            set { SetProperty(ref sex, value); }
        }

        [XmlIgnore]
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { SetProperty(ref phoneNumber, value); }
        }

        [XmlIgnore]
        private string city;
        public string City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }

        [XmlIgnore]
        private string image;
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        public Contact(string name, string lastName, DateTime birthday, Sex sex, string phoneNumber, string city, string image)
        {
            Name = name;
            LastName = lastName;
            Birthday = birthday;
            Sex = sex;
            PhoneNumber = phoneNumber;
            City = city;
            Image = image;
        }

        public Contact()
            : this (null, null, DateTime.Now, Sex.Female, null, null, null)
        {

        }
    }

    public enum Sex
    {
        [Description("male")]
        Male,
        [Description("female")]
        Female
    }

    [XmlRoot("ArrayOfContact")]
    public class ContactCollection
    {
        [XmlElement("Contact")]
        public List<Contact> Contacts { get; set; }
    }
}
