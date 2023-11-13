using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Media_Collection.Interfaces
{
	public interface INavigationAware
	{
		void OnNavigatedTo(object parameter);

		void OnNavigatedFrom();
	}
}
