using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using RTF.Mobile.Custom;
using RTF.Mobile.Droid.Resources.Renderers;
using Color = Android.Graphics.Color;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly:ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace RTF.Mobile.Droid.Resources.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var drawable = new GradientDrawable();
                drawable.Thickness = 2;
                drawable.SetColor(ColorStateList.ValueOf(Color.White));
                drawable.SetCornerRadius(15);
                drawable.SetStroke(2, ColorStateList.ValueOf(Color.Cyan));
                Control.SetBackground(drawable);
                Control.SetPadding(10, 3, 10, 3);
            }
        }

        public CustomEntryRenderer(Context context) : base(context)
        {
        }
    }
}