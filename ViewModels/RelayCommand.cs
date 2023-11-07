using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.UI.Xaml.Input;

////
namespace My_Media_Collection.ViewModels
{
	internal class relayCommand : ICommand
	{
		private readonly Action action;
		private readonly Func<bool> canExecute;
		public relayCommand(Action action) : this(action, null)
		{			
		}

		public relayCommand(Action action, Func<bool> canExecute)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));
			this.action = action;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter) => canExecute == null || canExecute();

		public void Execute(object parameter) => action();

		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}
}
