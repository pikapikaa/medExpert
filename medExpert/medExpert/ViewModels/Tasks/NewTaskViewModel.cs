using medExpert.Models;
using medExpert.Views.Tasks;
using medExpert.Views.Tasks.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Tasks
{
    public class NewTaskViewModel : INotifyPropertyChanged
    {
        private string title;
        private string text;
        private string responsiblePerson;
        private string expiration;
        private Priority priorityTask;
        private Regularity regularityTask;

        public INavigation Navigation { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        /// <summary>
        /// Содержимое задачи
        /// </summary>
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        /// <summary>
        /// Ответственный за выполнение
        /// </summary>
        public string ResponsiblePerson
        {
            get => responsiblePerson;
            set
            {
                responsiblePerson = value;
                OnPropertyChanged(nameof(ResponsiblePerson));
            }
        }

        /// <summary>
        /// Срок выполнения задачи
        /// </summary>
        public string Expiration
        {
            get => expiration;
            set
            {
                expiration = value;
                OnPropertyChanged(nameof(Expiration));
            }
        }

        /// <summary>
        /// Приоритет
        /// </summary>
        public Priority PriorityTask
        {
            get => priorityTask;
            set
            {
                priorityTask = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Повторяемость задачи
        /// </summary>
        public Regularity RegularityTask
        {
            get => regularityTask;
            set
            {
                regularityTask = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда открытия списка ответственных лиц
        /// </summary>
        public ICommand OpenResponsibleListView => new Command(async item =>
        {
            var context = new ResponsibleListViewModel()
            {
                IsNewTask = true,
                Navigation = this.Navigation
            };

            await Navigation.PushModalAsync(new NavigationPage(new ResponsibleListView() 
            {
                BindingContext = context
            }), true);
        });

        /// <summary>
        /// Команда выбора даты
        /// </summary>
        public ICommand OpenCalendarPopupView => new Command(async item =>
        {
            await PopupNavigation.Instance.PushAsync(new CalendarPopupView());
        });

        /// <summary>
        /// Команда выбора приоритета задачи
        /// </summary>
        public ICommand OpenPriorityPopupView => new Command(async item =>
        {
            await PopupNavigation.Instance.PushAsync(new PriorityPopupView());
        });

        /// <summary>
        /// Команда выбора повтора задачи
        /// </summary>
        public ICommand OpenRegularityTaskPopupView => new Command(async item =>
        {
            await PopupNavigation.Instance.PushAsync(new RegularityTaskPopupView());
        });


        /// <summary>
        /// Команда выбора даты напоминания задачи
        /// </summary>
        public ICommand OpenReminderDatePopupView => new Command(async item =>
        {
            await PopupNavigation.Instance.PushAsync(new ReminderDatePopupView());
        });

        /// <summary>
        /// Команда выбора даты(в часах и минутах) напоминания задачи
        /// </summary>
        public ICommand OpenReminderTimePopupView => new Command(async item =>
        {
            await PopupNavigation.Instance.PushAsync(new ReminderTimePickerPopupView());
        });

        public NewTaskViewModel()
        {
            ResponsiblePerson = "Введите сотрудника";
            Expiration = "Введите дату";

            MessagingCenter.Subscribe<Employee>(this,
             MessageKeys.AddResponsibleToNewTask, sender =>
             {
                 ResponsiblePerson = sender.FullName;
             });

            MessagingCenter.Subscribe<CalendarPopupViewModel>(this,
             MessageKeys.AddDateToNewTask, sender =>
             {
                 Expiration = $"{sender.SelectedDate:dd.MM.yyyy} г.";
             });

            MessagingCenter.Subscribe<PriorityPopupViewModel>(this,
               MessageKeys.AddPriorityToNewTask, sender =>
               {
                   PriorityTask = sender.SelectPriority;
               });

            MessagingCenter.Subscribe<RegularityTaskPopupViewModel>(this,
             MessageKeys.AddRegularityToNewTask, sender =>
             {
                 RegularityTask = sender.SelectRegularity;
             });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
