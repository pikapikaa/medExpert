using medExpert.ViewModels.Tasks;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace medExpert.Views.Tasks.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPopupView : PopupPage
    {
        public CalendarPopupView()
        {
            InitializeComponent();
            BindingContext = new CalendarPopupViewModel();
        }
    }
}