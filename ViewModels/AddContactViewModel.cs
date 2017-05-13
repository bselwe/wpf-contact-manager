using Contact_Manager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Contact_Manager.ViewModels
{
    public class AddContactViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public Contact Contact { get; set; } = new Contact();

        public event EventHandler Save;

        public AddContactViewModel()
        {
            CloseCommand = new RelayCommand(x => ((Window) x).Close());
            SaveCommand = new RelayCommand(x => Save(this, new EventArgs()), CanSave);
        }

        private bool CanSave(object sender)
        {
            return ViewValidator.IsValid(sender as DependencyObject);
        }

        public void Reset()
        {
            Contact = new Contact();
        }
    }
}
