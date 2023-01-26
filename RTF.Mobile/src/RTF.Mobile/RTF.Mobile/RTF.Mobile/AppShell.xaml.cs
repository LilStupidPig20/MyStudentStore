using RTF.Mobile.Views.Profile;
using RTF.Mobile.Views.Login;
using RTF.Mobile.Views.Register;
using Xamarin.Forms;
using RTF.Mobile.Views.Shop;
using RTF.Mobile.Views.Rules;
using RTF.Mobile.Views.Basket;
using RTF.Mobile.Views.Order;
using RTF.Mobile.Views.Calendar;

namespace RTF.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(QrPage), typeof(QrPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(ShopPage), typeof(ShopPage));
            Routing.RegisterRoute(nameof(ShopItemPage), typeof(ShopItemPage));
            Routing.RegisterRoute(nameof(RulesPage), typeof(RulesPage));
            Routing.RegisterRoute(nameof(BasketPage), typeof(BasketPage));
            Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
            Routing.RegisterRoute(nameof(CalendarPage), typeof(CalendarPage));
            Routing.RegisterRoute(nameof(CalendarEventPage), typeof(CalendarEventPage));
        }

    }
}
