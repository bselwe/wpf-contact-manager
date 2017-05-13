using Contact_Manager.ViewModels;
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
using System.Windows.Shapes;

namespace Contact_Manager.Views
{
    /// <summary>
    /// Interaction logic for AddContactView.xaml
    /// </summary>
    public partial class AddContactView : Window
    {
        public AddContactView()
        {
            InitializeComponent();
        }

        public AddContactView(Window parent, AddContactViewModel context) : this()
        {
            Owner = parent;
            DataContext = context;
            context.Save += Save;
        }

        void Save(object sender, EventArgs e)
        {
            Close();
        }
    }
}
