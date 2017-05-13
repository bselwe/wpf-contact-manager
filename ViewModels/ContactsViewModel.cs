using Contact_Manager.Helpers;
using Contact_Manager.Services;
using Contact_Manager.ViewModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Contact_Manager
{
    public class ContactsViewModel : BaseViewModel
    {
        #region Variables
        private ImageService imageService;
        private ImportService importService;
        private ExportService exportService;

        public AddContactViewModel AddContactViewModel { get; set; }

        public ICommand AddContactsListCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }
        public ICommand ImportContactsCommand { get; private set; }
        public ICommand ExportContactsCommand { get; private set; }
        public ICommand ChooseImageCommand { get; private set; }
        
        public ObservableRangeCollection<Contact> Contacts { get; private set; }

        public ICollectionView ContactsView { get; set; }

        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set { SetProperty(ref selectedContact, value); }
        }

        private string contactsFilter;
        public string ContactsFilter
        {
            get { return contactsFilter; }
            set
            {
                SetProperty(ref contactsFilter, value);
                SelectedContact = null;
                ContactsView.Refresh();
            }
        }
        #endregion

        public ContactsViewModel()
        {
            imageService = ImageService.Instance;
            importService = ImportService.Instance;
            exportService = ExportService.Instance;

            AddContactViewModel = new AddContactViewModel();
            AddContactViewModel.Save += AddContactViewModelOnSave;

            Contacts = new ObservableRangeCollection<Contact>();
            ContactsView = CollectionViewSource.GetDefaultView(Contacts);
            ContactsView.Filter = ContactsViewFilter;

            AddContactsListCommand = new RelayCommand(AddContactsList);
            DeleteContactCommand = new RelayCommand(DeleteContact);
            ImportContactsCommand = new RelayCommand(ImportContacts);
            ExportContactsCommand = new RelayCommand(ExportContacts);
            ChooseImageCommand = new RelayCommand(ChooseImage);
        }

        private void AddContactViewModelOnSave(object sender, EventArgs args)
        {
            Contacts.Add(AddContactViewModel.Contact);
            AddContactViewModel.Reset();
        }

        private bool ContactsViewFilter(object o)
        {
            var contact = (o as Contact);

            if (String.IsNullOrWhiteSpace(ContactsFilter))
            {
                if (SelectedContact == null && ContactsFilter != null)
                    SelectedContact = contact;

                return true;
            }
            
            var keywords = ContactsFilter.Trim().Split(' ');
            var data = new string[] { contact.Name, contact.LastName, contact.City, contact.PhoneNumber };
            bool result = keywords.Where(x => data.Where(y => y.ToLower().Contains(x.ToLower())).Any()).Any();

            if (result && SelectedContact == null)
                SelectedContact = contact;

            return result;
        }

        private void AddContactsList(object sender)
        {
            var contactsGenerator = new RandomContactsGenerator();
            var randomContacts = contactsGenerator.GenerateContacts(10);

            // AddRange not working - fix
            foreach (var contact in randomContacts)
                Contacts.Add(contact);
        }

        private void DeleteContact(object sender)
        {
            Contacts.Remove(SelectedContact);
            SelectedContact = null;
        }

        private void ImportContacts(object sender)
        {
            var contactsImported = importService.ImportContacts();

            if (!contactsImported.Any())
                return;

            foreach (var contact in contactsImported)
                Contacts.Add(contact);
        }

        private void ExportContacts(object sender)
        {
            exportService.ExportContacts(Contacts);
        }

        private void ChooseImage(object sender)
        {
            if (SelectedContact == null)
            {
                MessageBox.Show("Select a contact first.");
                return;
            }

            imageService.ChooseImage(SelectedContact);
        }
    }
}
