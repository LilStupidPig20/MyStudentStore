using Xamarin.Forms;

namespace RTF.Mobile.Utils.Models
{
    public interface IEditableViewModel
    {
        Command SaveCommand { get; }

        Command CancelCommand { get; }
    }
}
