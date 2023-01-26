using Xamarin.Forms;

namespace RTF.Mobile.Utils.PageInt
{
    public interface IShellViewModel
    {
        bool IsRefreshing { get; set; }

        Command RefreshCommand { get; }
    }
}
