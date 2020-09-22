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
        /// Вид проверки
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
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
