using Xamarin.Forms;

namespace RTF.Mobile.Utils.Models
{
    public class EditableViewModel : BaseViewModel, IEditableViewModel
    {
        public Command SaveCommand { get; }

        public Command CancelCommand { get; }
    }
}
