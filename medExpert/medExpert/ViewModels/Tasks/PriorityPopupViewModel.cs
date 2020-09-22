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
    public class PriorityPopupViewModel : INotifyPropertyChanged
    {
        private int prioritiesListViewHeight;
        private Priority selectPriority;

        /// <summary>
        /// Высота ListView приоритета задач
        /// </summary>
        public int PrioritiesListViewHeight
        {
            get => prioritiesListViewHeight;
            set
            {
                prioritiesListViewHeight = value;
                OnPropertyChanged(nameof(PrioritiesListViewHeight));
            }
        }

        /// <summary>
        /// Выбранный приоритет
        /// </summary>
        public Priority SelectPriority
        {
            get => selectPriority;
            set
            {
                selectPriority = value;
                OnPropertyChanged(nameof(SelectPriority));
            }
        }

        /// <summary>
        /// Коллекция приоритетов задач
        /// </summary>
        public ObservableCollection<Priority> Priorities => new ObservableCollection<Priority>()
        {
            Priority.Low,
            Priority.Medium,
            Priority.High,
            Priority.Urgent,
            Priority.Critical
        };

        /// <summary>
        /// Команда выбора приоритета
        /// </summary>
        public ICommand SelectPriorityCommand => new Command<Priority>(async item =>
        {
            SelectPriority = item;
            MessagingCenter.Send(this, MessageKeys.AddPriorityToNewTask);
            await PopupNavigation.Instance.PopAsync();
        }); 

        public PriorityPopupViewModel()
        {
            var count = Priorities?.Count;
            PrioritiesListViewHeight = (int)(count * 45);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
