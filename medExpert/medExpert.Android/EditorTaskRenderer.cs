using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using medExpert.Droid;
using medExpert.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditorRenderer), typeof(EditorTaskRenderer))]
namespace medExpert.Droid
{
    public class EditorTaskRenderer : EditorRenderer
    {
        public EditorTaskRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Control.BackgroundTintList = ColorStateList.ValueOf(Xamarin.Forms.Color.Transparent.ToAndroid());
            }
            else
            {
                Control.Background.SetColorFilter(Xamarin.Forms.Color.Transparent.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }
    }
}