using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Navigation;

namespace My_Media_Collection.Interfaces
{
	
	
		public interface INavigationService
		{
			string CurrentPage { get; }
			void NavigateTo(string page);
			void NavigateTo(string page, object parameter);
			void GoBack();
		}
	
}
