using medExpert.Models;
using medExpert.ViewModels.Audits;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace medExpert.Views.Audits.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuImagePopupView : PopupPage
    {
        public MenuImagePopupView()
        {
            InitializeComponent();
            BindingContext = new MenuImagePopupViewModel();
        }

        private void TapGestureRecoDeleteImageBtngnizer_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, MessageKeys.AscendingSort);
        }
    }
}