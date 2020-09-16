using medExpert.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using SfCalendarSelectionChangedEventArgs = Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs;

namespace medExpert.ViewModels.Tasks
{
    public class RangeCalendarTasksPopupViewModel : INotifyPropertyChanged
    {
        private DateTime? dateIn;
        private DateTime? dateOut;

        /// <summary>
        /// Культура
        /// </summary>
        public CultureInfo Culture => new CultureInfo("ru-RU", false);


        /// <summary>
        /// Команда выбора диапазона дат в календаре
        /// </summary>
        public ICommand DateRangeSelectionCommand => new Command<SfCalendarSelectionChangedEventArgs>(args =>
        {
            this.dateIn = null;
            this.dateOut = null;

            if (args.DateAdded.Count > 1)
            {
                this.dateIn = args.DateAdded.Min();
                this.dateOut = args.DateAdded.Max();
            }
        });

        /// <summary>
        /// Команда выбора выбранного периода
        /// </summary>
        public ICommand SelectRangeCommand => new Command(async () =>
        {
            if (dateIn.HasValue)
            {
                //MessagingCenter.Send(this, MessageKeys.SelectRangeDates,
                //    Tuple.Create<DateTime, DateTime>(dateIn.Value, dateOut.Value));

                await PopupNavigation.Instance.PopAsync();
            }
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}