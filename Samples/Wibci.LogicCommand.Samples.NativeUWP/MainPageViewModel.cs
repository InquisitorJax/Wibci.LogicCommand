using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Wibci.LogicCommand.Samples.NativeUWP.Commands;
using Windows.UI.Popups;

namespace Wibci.LogicCommand.Samples.NativeUWP
{
	public class MainPageViewModel : BindableBase
	{
		public MainPageViewModel()
		{
			ChoosePictureCommand = new DelegateCommand(ChoosePicture);
		}

		public ICommand ChoosePictureCommand { get; }

		private async void ChoosePicture()
		{
			var command = new ChoosePictureCommand();
			var result = await command.ExecuteAsync(ChoosePictureContext.Default);

			string message = "";

			if (result.IsValid(NotificationSeverity.Warning) && result.File != null)
			{
				message = $"You picked file: {result.File.DisplayName}";
			}
			else
			{
				message = "No File Picked :(";
			}
			var dialog = new MessageDialog(message);
			dialog.ShowAsync();
		}
	}
}