using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.NavigationDrawer;
using יצירת_קורות_חיים.Pages;

namespace יצירת_קורות_חיים
{
    class NavationItemClickedAction : TargetedTriggerAction<Grid>
    {
        UserControl userControl = null;
        protected override void Invoke(object parameter)
        {
            var args = parameter as NavigationItemClickedEventArgs;
            if (args == null)
                return;

            if (args.Item.ItemType != ItemType.Tab)
                return;

            var pagename = args.Item.Header.ToString();

            if (pagename == "בית")
            {
                userControl = new HomeControl();
            }
            if (pagename == "יצירת קורות חיים")
            {
                userControl = new CreatesVCControl();
            }
            if (pagename == "תבנית חיים")
            {
                userControl = new LifePattern();
            }
            if (pagename == "יצירת אתר תדמית")
            {
                userControl = new CreatesWebSiteVC();
            }
            else
            {
                (((this.Target as Grid).Children[0] as UserControl).Content as TextBlock).Text = string.Empty;
            }
           ((this.Target as Grid).Children[1] as UserControl).Content = userControl;
        }
    }
}
