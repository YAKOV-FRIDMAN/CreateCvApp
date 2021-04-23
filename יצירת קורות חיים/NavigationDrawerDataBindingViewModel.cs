#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using MaterialDesignThemes.Wpf;
using Syncfusion.PMML;
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace יצירת_קורות_חיים
{
	public class Category
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private object icon;
		public object Icon
		{
			get { return icon; }
			set { icon = value; }
		}
	}
	public class NavigationDrawerDataBindingViewModel : NotificationObject
	{
		private object categorySelectedItem;
		public object CategorySelectedItem
		{
			get { return categorySelectedItem; }
			set { categorySelectedItem = value; }
		}

		Binding pathFillBinding = new Binding();
		public ObservableCollection<Category> Categories { get; set; }
		public NavigationDrawerDataBindingViewModel()
		{
			pathFillBinding.Path = new PropertyPath(TextBlock.ForegroundProperty);
			pathFillBinding.RelativeSource = new RelativeSource { Mode = RelativeSourceMode.Self };
			pathFillBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

			PackIcon homeIcon = new PackIcon();
			homeIcon.Kind = PackIconKind.Home;
			homeIcon.Height = 18;
			homeIcon.Width = 16;
			homeIcon.HorizontalAlignment = HorizontalAlignment.Center;
			homeIcon.VerticalAlignment = VerticalAlignment.Center;
			homeIcon.SetBinding(Path.DataProperty, pathFillBinding);




			PackIcon penIcon = new PackIcon();
			penIcon.Kind = PackIconKind.Pen;
			penIcon.Height = 18;
			penIcon.Width = 16;
			penIcon.HorizontalAlignment = HorizontalAlignment.Center;
			penIcon.VerticalAlignment = VerticalAlignment.Center;
			penIcon.SetBinding(Path.DataProperty, pathFillBinding);
			
			PackIcon bookIcon = new PackIcon();
			bookIcon.Kind = PackIconKind.Book;
			bookIcon.Height = 18;
			bookIcon.Width = 16;
			bookIcon.HorizontalAlignment = HorizontalAlignment.Center;
			bookIcon.VerticalAlignment = VerticalAlignment.Center;
			bookIcon.SetBinding(Path.DataProperty, pathFillBinding);
		
			PackIcon webIcon = new PackIcon();
			webIcon.Kind = PackIconKind.Web;
			webIcon.Height = 18;
			webIcon.Width = 16;
			webIcon.HorizontalAlignment = HorizontalAlignment.Center;
			webIcon.VerticalAlignment = VerticalAlignment.Center;
			webIcon.SetBinding(Path.DataProperty, pathFillBinding);

			Categories = new ObservableCollection<Category>();
			Categories.Add(new Category()
			{
				Name = "בית",
				Icon = homeIcon
			});
			Categories.Add(new Category()
			{
				Name = "יצירת קורות חיים",
				Icon = penIcon
			});
			Categories.Add(new Category()
			{
				Name = "תבנית חיים",
				Icon = bookIcon
			});
			Categories.Add(new Category()
			{
				Name = "יצירת אתר תדמית",
				Icon = webIcon
			});
			CategorySelectedItem = Categories[0];
		}
	}
}
