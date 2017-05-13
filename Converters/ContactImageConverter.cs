using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Contact_Manager.Converters
{
    public class ContactImageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Where(x => x == DependencyProperty.UnsetValue).Any())
                return null;

            if (values.Length != 2 || !(values[1] is Sex))
                return null;
            
            var imageConverter = new ImageSourceConverter();
            var sex = (Sex) values[1];
            var image = values[0] != null ? values[0].ToString() : null;
            var imageDefault = String.Concat(Config.ResourcesPath, sex.Equals(Sex.Male) ? "man.png" : "woman.jpg");

            // Image not provided
            if (String.IsNullOrEmpty(image) || !File.Exists(image))
                return imageConverter.ConvertFromString(imageDefault);

            try
            {
                return imageConverter.ConvertFromString(image);
            }
            catch(Exception ex)
            {
                // Image not found
                return imageConverter.ConvertFromString(imageDefault);
            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
