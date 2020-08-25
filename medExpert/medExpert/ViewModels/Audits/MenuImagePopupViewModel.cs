using medExpert.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class MenuImagePopupViewModel
    {
        /// <summary>
        /// Команда для удаления изображения
        /// </summary>
        public ICommand DeleteImagePress => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
            MessagingCenter.Send(this, MessageKeys.DeletePhoto);
        });
    }
}
