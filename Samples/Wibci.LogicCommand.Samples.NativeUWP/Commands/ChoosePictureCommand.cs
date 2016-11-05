using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Wibci.LogicCommand.Samples.NativeUWP.Commands
{
    public interface IChoosePictureCommand : IAsyncLogicCommand<ChoosePictureContext, ChoosePictureResult>
    {
    }

    public class ChoosePictureCommand : AsyncLogicCommand<ChoosePictureContext, ChoosePictureResult>, IChoosePictureCommand
    {
        public override async Task<ChoosePictureResult> ExecuteAsync(ChoosePictureContext request)
        {
            var retResult = new ChoosePictureResult();

            var openPicker = new FileOpenPicker
            {
                ViewMode = request.ViewMode,
                SuggestedStartLocation = request.SuggestedStartLocation
            };
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            var file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                retResult.File = file;
            }
            else
            {
                retResult.Notification.Add("File Empty", NotificationSeverity.Warning);
            }

            return retResult;
        }
    }

    public class ChoosePictureContext
    {
        public ChoosePictureContext()
        {
            SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            ViewMode = PickerViewMode.Thumbnail;
        }

        public static ChoosePictureContext Default
        {
            get { return new ChoosePictureContext(); }
        }

        public PickerLocationId SuggestedStartLocation { get; set; }

        public PickerViewMode ViewMode { get; set; }
    }

    public class ChoosePictureResult : CommandResult
    {
        public StorageFile File { get; set; }
    }
}