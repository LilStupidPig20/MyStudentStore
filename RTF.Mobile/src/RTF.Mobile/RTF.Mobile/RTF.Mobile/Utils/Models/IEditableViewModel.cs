using Microsoft.Toolkit.Mvvm.Input;

namespace RTF.Mobile.Utils.Models
{
    public interface IEditableViewModel
    {
        RelayCommand SaveCommand { get; }

        RelayCommand CancelCommand { get; }
    }
}
