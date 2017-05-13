using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    public static class Config
    {
        public static string ResourcesPath
        {
            get
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                return $"pack://application:,,,/{assemblyName};component/Resources/";
            }
        }
    }
}
