using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace medExpert.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskContentView : ContentView
    {
        public TaskContentView()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty ParentContextProperty =
           BindableProperty.Create("ParentContext", typeof(object),
               typeof(TaskContentView), null, propertyChanged: OnParentContextPropertyChanged);

        public object ParentContext
        {
            get { return GetValue(ParentContextProperty); }
            set { SetValue(ParentContextProperty, value); }
        }

        private static void OnParentContextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                (bindable as TaskContentView).ParentContext = newValue;
            }
        }
    }
}