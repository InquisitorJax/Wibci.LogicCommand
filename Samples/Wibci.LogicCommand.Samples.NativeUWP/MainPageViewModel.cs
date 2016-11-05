using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Wibci.LogicCommand.Samples.NativeUWP.Commands;
using Windows.UI.Popups;

namespace Wibci.LogicCommand.Samples.NativeUWP
{
    public class MainPageViewModel : BindableBase
    {
        public MainPageViewModel()
        {
            ChoosePictureCommand = DelegateCommand.FromAsyncHandler(ChoosePictureAsync);
        }

        public ICommand ChoosePictureCommand { get; }

        private async Task ChoosePictureAsync()
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
            await dialog.ShowAsync();
        }
    }
}