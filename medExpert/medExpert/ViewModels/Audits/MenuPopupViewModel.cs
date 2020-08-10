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
        /// <summary>
        /// Команда для выбора конца периода проверки
        /// </summary>
        public ICommand OpenSortPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
            await PopupNavigation.Instance.PushAsync(new SortPopupView());
        });
    }
}