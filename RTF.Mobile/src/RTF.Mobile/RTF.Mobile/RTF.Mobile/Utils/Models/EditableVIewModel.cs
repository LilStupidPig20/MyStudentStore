using System;
using Xamarin.Forms;

namespace RTF.Mobile.Utils.Models
{
    public class EditableViewModel : BaseViewModel, IEditableViewModel
    {
        public EditableViewModel() : base()
        {
        }

        public EditableViewModel(Guid id) : base(id)
        {
        }

        public Command SaveCommand { get; }

        public Command CancelCommand { get; }
    }
}
