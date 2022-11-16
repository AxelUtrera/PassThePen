using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PassThePen
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzU5OTk1QDMyMzAyZTMzMmUzMFhNYVJmMHRUdzZOb3VuREtLSXNvdWo5bXV2a2VzcG8zeGNIekJZUklHaUU9");
        }
    }
}
