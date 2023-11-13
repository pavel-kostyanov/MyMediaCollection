using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using My_Media_Collection.Interfaces;
using My_Media_Collection.ViewModels;
using My_Media_Collection.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace My_Media_Collection
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : Window
	{
		
		public MainWindow()
		{
			
			this.InitializeComponent();
			App.ShellFrame = MainWindowFrame;
			//MainWindowFrame.Content = new Main();
		}

		private void MainMenu_OnLoaded(object sender, RoutedEventArgs e)
		{
			//App.ShellFrame = MainWindowFrame;
			//MainWindowFrame.Content = new Main();
		}

		private void MainMenu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			var nav = App.HostContainer.Services.GetService<INavigationService>();
			nav.NavigateTo((string)args.InvokedItemContainer.Tag, null);

		}
/*
		private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			switch (args.InvokedItemContainer.Tag)
			{
				case "Home":
					//navigate to home
					MainWindowFrame.Navigate(typeof(Main));
					break;
				case "About":
					//navigate to About us
					MainWindowFrame.Navigate(typeof(About));
					break;
			}
		}
		*/
	}
}

