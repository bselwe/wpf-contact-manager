using Contact_Manager.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager.Services
{
    public class ImageService
    {
        public void ChooseImage(Contact contact)
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "Select a picture";
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (dlg.ShowDialog() == true)
            {
                contact.Image = dlg.FileName;
            }
        }

        #region Singleton
        private static readonly Lazy<ImageService> lazy = new Lazy<ImageService>(() => new ImageService());

        public static ImageService Instance
        {
            get { return lazy.Value; }
        }

        private ImageService()
        {
        }
        #endregion
    }
}
