using Contact_Manager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Contact_Manager
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : Window
    {
        public ContactsView()
        {
            InitializeComponent();
            DataContext = new ContactsViewModel();
        }

        void OnAddContactClick(object sender, EventArgs e)
        {
            var addContactDialogBox = new AddContactView(this, ((ContactsViewModel) this.DataContext).AddContactViewModel);
            addContactDialogBox.ShowDialog();
        }
    }
}
