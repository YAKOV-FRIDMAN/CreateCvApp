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
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using יצירת_קורות_חיים.ViewModels;
using Syncfusion.SfSkinManager;

namespace יצירת_קורות_חיים.Pages
{
    /// <summary>
    /// Interaction logic for CreatesVCControl1.xaml
    /// </summary>
    
    public partial class CreatesVCControl : UserControl
    {
       // [STAThread]
        public CreatesVCControl()
        {
           // SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Office2019HighContrastWhite" });
            //SfSkinManager.SetVisualStyle(this, VisualStyles.Office2019HighContrastWhite);
            InitializeComponent();
            var d = (CreateVC)DataContext;
            d.LoadWord += (s, e) =>
            {
                 var path = System.IO.Path.Combine("", "Hello World.doc");
                 richTextBoxAdv.Load(@"C:\Users\user1\source\repos\יצירת קורות חיים\יצירת קורות חיים\bin\Debug\net5.0-windows\Hello World.doc");
            };
        }
        public CreatesVCControl(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        private void wizar_SelectedPageChanged(object sender, RoutedEventArgs e)
        {
            ContentCustomization.SelectedIndex = wizar.Items.IndexOf(wizar.SelectedWizardPage);
        }

    
    }
}
