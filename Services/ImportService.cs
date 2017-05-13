using Contact_Manager.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Contact_Manager.Services
{
    public class ImportService
    {
        public IList<Contact> ImportContacts()
        {
            var contacts = new List<Contact>();
            var dlg = new OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            
            if (dlg.ShowDialog() == true)
            {
                string fileName = dlg.FileName;
                var deserializer = new XMLSerializer<ContactCollection>(fileName);

                ContactCollection contactCollection = null;

                try
                {
                    contactCollection = deserializer.Deserialize();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                contacts = contactCollection?.Contacts;
            }

            return contacts;
        }

        #region Singleton
        private static readonly Lazy<ImportService> lazy = new Lazy<ImportService>(() => new ImportService());

        public static ImportService Instance
        {
            get { return lazy.Value; }
        }

        private ImportService()
        {
        }
        #endregion
    }
}
