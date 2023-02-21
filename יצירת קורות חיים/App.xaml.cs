using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Syncfusion;
using Syncfusion.Licensing;
using Syncfusion.SfSkinManager;

namespace יצירת_קורות_חיים
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string path = Directory.GetCurrentDirectory();
        public App()
        {
            //SyncfusionLicenseProvider.RegisterLicense("@31392e312e30VhY82/n8xKMo1ER5qDxXDcZ3O/rtaJn9YDmpq4WkzT0=");
            SyncfusionLicenseProvider.RegisterLicense("NDQwMTM0QDMxMzkyZTMxMmUzMGQ0NGNYdGNsRWl6OFlrQUh5L1VrSGZ5aGVnS0l0aFovQkRkTGJMOUo1ckU9");
        }
    }
}
