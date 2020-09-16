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

[assembly: ExportRenderer(typeof(CustomEditorRenderer), typeof(EditorTaskRenderer))]
namespace medExpert.iOS
{
    public class EditorTaskRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            //???? нужно добавить обработчик для удаления линии
        }
    }
}