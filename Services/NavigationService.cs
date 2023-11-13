using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using My_Media_Collection.Interfaces;
using My_Media_Collection;
using My_Media_Collection.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace My_Media_Collection.Services
{
	public class NavigationService : INavigationService
	{
		private readonly IDictionary<string, Type> _pages = new ConcurrentDictionary<string, Type>();
		private static Frame AppFrame;
		public const string RootPage = "(Main)";
		public const string UnknownPage = "(Unknown)";

		public NavigationService (Frame shellFrame)
		{
			AppFrame = shellFrame;
		}
		// Gets the name of the currently displayed page.
		public string CurrentPage
		{
			get
			{
				var frame = AppFrame;

				if (frame.BackStackDepth == 0)
					return RootPage;

				if (frame.Content == null)
					return UnknownPage;

				var type = frame.Content.GetType();

				if (_pages.Values.All(v => v != type))
					return UnknownPage;

				var item = _pages.Single(i => i.Value == type);

				return item.Key;
			}
		}
		public void Configure(string page, Type type)
		{
			if (_pages.Values.Any(v => v == type))
			{
				throw new ArgumentException($"The {type.Name} view has already been registered under another name.");
			}
			_pages[page] = type;
		}

		public void NavigateTo(string page)
		{
			NavigateTo(page, null);
		}
		public void NavigateTo(string page, object parameter)
		{
			if (!_pages.ContainsKey(page))
			{
				throw new ArgumentException($"Unable to find a page registered with the name { page }.");
			}			
			
			AppFrame.Navigate(_pages[page], parameter);			
		}
		public void GoBack()
		{
			if (AppFrame?.CanGoBack == true)
			{
				AppFrame.GoBack();
			}
		}
	}
}

