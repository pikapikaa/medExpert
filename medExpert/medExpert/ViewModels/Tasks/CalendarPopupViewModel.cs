using medExpert.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Tasks
{
    public class CalendarPopupViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Выбранная дата
        /// </summary>
        public DateTime? SelectedDate { get; set; }

        /// <summary>
        /// Язык
        /// </summary>
        public CultureInfo Culture => new CultureInfo("ru-RU", false);

        /// <summary>
        /// Команда выбора выбранного периода
        /// </summary>
        public ICommand SelectDateCommand => new Command(async () =>
        {
            if (SelectedDate.HasValue)
            {
                MessagingCenter.Send(this, MessageKeys.AddDateToNewTask);
                await PopupNavigation.Instance.PopAsync();
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
    }
}