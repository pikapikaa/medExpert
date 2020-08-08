using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using medExpert.iOS;
using medExpert.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntryRenderer), typeof(EntrySearchRenderer))]
namespace medExpert.iOS
{
    public class EntrySearchRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}