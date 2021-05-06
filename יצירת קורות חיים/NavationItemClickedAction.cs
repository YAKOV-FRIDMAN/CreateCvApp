using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.NavigationDrawer;
using יצירת_קורות_חיים.Pages;
using יצירת_קורות_חיים.ViewModels;

namespace יצירת_קורות_חיים
{
    class NavationItemClickedAction : TargetedTriggerAction<Grid>
    {
        UserControl userControl = null;
        // Thread t;


        [STAThread]
        protected override void Invoke(object parameter)
        {
            var args = parameter as NavigationItemClickedEventArgs;
            if (args == null)
                return;

            if (args.Item.ItemType != ItemType.Tab)
                return;

            var pagename = args.Item.Header.ToString();

            //MessageBox.Show("אתה בטוח שאתב רוצה לעזור", "השינוים לא ישמרו", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            if (pagename == "בית")
            {
                if (userControl != null)
                    GC.SuppressFinalize(userControl);
                userControl = new HomeControl();
            }
            else if (pagename == "יצירת קורות חיים")
            {
                if (userControl != null)
                    GC.SuppressFinalize(userControl);
                userControl = new CreatesVCControl();
                var d = (CreateVC)userControl.DataContext;
                //t = new Thread(FuncCreateVc);
                //t.SetApartmentState(ApartmentState.STA);
                d.RefreshPage += (o, e) =>
                {
                    GC.SuppressFinalize(userControl);
                    userControl = new CreatesVCControl();
                    // t.Start();
                };

            }
            else if (pagename == "תבנית חיים")
            {
                if (userControl != null)
                    GC.SuppressFinalize(userControl);
                userControl = new LifePattern();
            }
            else if (pagename == "יצירת אתר תדמית")
            {
                if (userControl != null)
                    GC.SuppressFinalize(userControl);
                userControl = new CreatesWebSiteVC();
            }
            else
            {
                (((this.Target as Grid).Children[0] as UserControl).Content as TextBlock).Text = string.Empty;
            }
             (((this.Target as Grid).Children[0] as UserControl).Content as TextBlock).Text = pagename;
            ((this.Target as Grid).Children[1] as UserControl).Content = userControl;
        }


        [STAThread]
        private void FuncCreateVc(object obj)
        {
            GC.SuppressFinalize(userControl);
            userControl = new CreatesVCControl();
        }
    }
}
