using medExpert.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Tasks
{
    public class RegularityTaskPopupViewModel : INotifyPropertyChanged
    {
        private int regularitiesListViewHeight;
        private Regularity selectRegularity;

        /// <summary>
        /// Высота ListView
        /// </summary>
        public int RegularitiesListViewHeight
        {
            get => regularitiesListViewHeight;
            set
            {
                regularitiesListViewHeight = value;
                OnPropertyChanged(nameof(RegularitiesListViewHeight));
            }
        }

        /// <summary>
        /// Выбранная повторяемость
        /// </summary>
        public Regularity SelectRegularity
        {
            get => selectRegularity;
            set
            {
                selectRegularity = value;
                OnPropertyChanged(nameof(SelectRegularity));
            }
        }

        /// <summary>
        /// Коллекция видов повторяемости задач
        /// </summary>
        public ObservableCollection<Regularity> Regularities => new ObservableCollection<Regularity>()
        {
            Regularity.Daily,
            Regularity.Weekly,
            Regularity.Monthly
        };

        /// <summary>
        /// Команда выбора повторяемости
        /// </summary>
        public ICommand SelectRegularityCommand => new Command<Regularity>(async item =>
        {
            SelectRegularity = item;
            MessagingCenter.Send(this, MessageKeys.AddRegularityToNewTask);
            await PopupNavigation.Instance.PopAsync();
        });

        public RegularityTaskPopupViewModel()
        {
            var count = Regularities?.Count;
            RegularitiesListViewHeight = (int)(count * 42);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}