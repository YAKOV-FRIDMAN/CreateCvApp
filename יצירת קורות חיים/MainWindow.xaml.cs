using Syncfusion.Windows.Tools.Controls;
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
using יצירת_קורות_חיים.Pages;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using Syncfusion.Windows.Shared;
//using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Syncfusion.SfSkinManager;

namespace יצירת_קורות_חיים
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SfSkinManager.ApplyStylesOnApplication = true;
            //try
            //{

            //}
            //catch (Exception)
            //{
            //    throw new ArgumentException(Environment.GetResourceString(GetResourceName(resource)));

            //}
          //  SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            InitializeComponent();
            //  SfSkinManager.SetVisualStyle(this, VisualStyles.Office2019Colorful);
            var userControl = new HomeControl();
            contentView.Content = userControl.Content;

        }
        public MainWindow(string themename)
        {
            InitializeComponent();
        }


    }
}
