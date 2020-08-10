using medExpert.Views.Audits;
using medExpert.Views.Audits.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class MenuPopupViewModel
    {
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Команда для выбора конца периода проверки
        /// </summary>
        public ICommand OpenSortPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
            await PopupNavigation.Instance.PushAsync(new SortPopupView());
        });

        /// <summary>
        /// Команда для выбора конца периода проверки
        /// </summary>
        public ICommand OpenNewStructuralUnitCommand => new Command(async () =>
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewStructuralUnitView()), true);
            await PopupNavigation.Instance.PopAsync();
        });
    }
}