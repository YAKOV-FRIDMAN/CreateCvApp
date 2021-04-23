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
using יצירת_קורות_חיים.ViewModels;

namespace יצירת_קורות_חיים.Pages
{
    /// <summary>
    /// Interaction logic for CreatesVCControl1.xaml
    /// </summary>
    public partial class CreatesVCControl : UserControl
    {
        public CreatesVCControl()
        {
            InitializeComponent();
           
        }


        private void wizar_SelectedPageChanged(object sender, RoutedEventArgs e)
        {
            ContentCustomization.SelectedIndex = wizar.Items.IndexOf(wizar.SelectedWizardPage);

        }

     
    }
}
