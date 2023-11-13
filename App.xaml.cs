using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using My_Media_Collection.Interfaces;
using My_Media_Collection.Services;
using My_Media_Collection.ViewModels;
using My_Media_Collection.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace My_Media_Collection
{

	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	public partial class App : Application
	{
		public static IHost HostContainer { get; private set; }
		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			this.InitializeComponent();
		}

		internal static Frame ShellFrame;


		//public static MainViewModel ViewModel { get; } = new MainViewModel();
		//public static Frame ShellFrame { get; set; }

		/// <summary>
		/// Invoked when the application is launched.
		/// </summary>
		/// <param name="args">Details about the launch request and process.</param>
		protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
		{
			ShellFrame = new Frame();
			m_window = new MainWindow();
			
			RegisterComponents(ShellFrame);

			ShellFrame.NavigationFailed += ShellFrame_NavigationFailed;
			ShellFrame.Navigate(typeof(Main), args);
			//m_window.Content = ShellFrame;
			m_window.Activate();

		}

		private void ShellFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception($"Error loading page { e.SourcePageType.FullName }");
		}

		private Window m_window;

		private void RegisterComponents(Frame ShellFrame)
		{
			
			var navigationService = new NavigationService(ShellFrame);
			navigationService.Configure(nameof(Main), typeof(Main));
			navigationService.Configure(nameof(DetailPage), typeof(DetailPage));
			navigationService.Configure(nameof(About), typeof(About));

			HostContainer = Host.CreateDefaultBuilder().ConfigureServices(services => 
				{
					services.AddSingleton<INavigationService>(navigationService);
					services.AddTransient<MainViewModel>();					
					//services.AddSingleton<IDatabaseService, DatabaseService>();					
					services.AddTransient<DetailPageViewModel>();
				}).Build();
			
		}
	}
}
