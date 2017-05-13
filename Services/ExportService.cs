using Contact_Manager.Helpers;
using Contact_Manager.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Contact_Manager.Services
{
    public class ExportService
    {
        public void ExportContacts(IList<Contact> contacts)
        {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";

            if (dlg.ShowDialog() == true)
            {
                string fileName = dlg.FileName;

                var serializer = new XMLSerializer<ContactCollection>(fileName);

                var contactCollection = new ContactCollection();
                contactCollection.Contacts = contacts.ToList();

                try
                {
                    serializer.Serialize(contactCollection);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #region Singleton
        private static readonly Lazy<ExportService> lazy = new Lazy<ExportService>(() => new ExportService());

        public static ExportService Instance
        {
            get { return lazy.Value; }
        }

        private ExportService()
        {
        }
        #endregion
    }
}
