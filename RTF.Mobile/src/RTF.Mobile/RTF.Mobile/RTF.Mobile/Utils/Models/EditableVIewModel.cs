using Microsoft.Toolkit.Mvvm.Input;

namespace RTF.Mobile.Utils.Models
{
    public class EditableViewModel : BaseViewModel, IEditableViewModel
    {
        public RelayCommand SaveCommand { get; }

        public RelayCommand CancelCommand { get; }
    }
}
