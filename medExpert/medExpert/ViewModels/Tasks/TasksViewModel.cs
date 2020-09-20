using medExpert.Models;
using medExpert.Views.Tasks;
using medExpert.Views.Tasks.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static medExpert.ViewModels.Audits.AuditListViewModel;

namespace medExpert.ViewModels.Tasks
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        private ObservableCollection<Task> tasks;
        private ObservableCollection<Task> filteredTasks;
        private ObservableCollection<Task> unfilteredTasks;
        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public TasksViewModel()
        {
            var _listOfItems = new DataTaskFactory().GetTasks();
            Tasks = new ObservableCollection<Task>(_listOfItems);
            unfilteredTasks = new ObservableCollection<Task>(_listOfItems);
        }

        /// <summary>
        /// Команда открытия окна меню
        /// </summary>
        public ICommand OpenMenuTaskPopupCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PushAsync(new MenuTaskPopupView(), false);
        });

        /// <summary>
        /// Команда открытия детального представления задачи
        /// </summary>
        public ICommand OpenTaskDetailCommand => new Command<Task>(async task =>
        {
            var context = new TaskDetailViewModel()
            {
                Title = task.Title,
                Text = task.Text,
                Expiration = task.PeriodDateOutText,
                Responsible = task.Responsible
            };

            await Navigation.PushAsync(new TaskDetailView() 
            {
                BindingContext = context
            });
        });

        /// <summary>
        /// Команда нажатия чек-бокса для задачи
        /// </summary>
        public ICommand ClickCheckBox => new Command<Task>(item =>
        {
            filteredTasks = new ObservableCollection<Task>(tasks.Where(i => i.Id == item.Id));
            Tasks.Remove(item);
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal class DataTaskFactory
        {
            public List<Task> GetTasks()
            {
                return new List<Task>()
                {
                    new Task()
                    {
                        Id = 1,
                        Num = 42443,
                        Location = "ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                        PeriodDateIn = new DateTime(2020, 7, 5),
                        PeriodDateOut = new DateTime(2020, 7, 10),
                        RemindTime = new DateTime(2020, 10, 10),
                        Priority = TaskPriority.High,
                        Status = TaskStatus.New,
                        Responsible = "Иванов Иван Иванович",
                        Title = "Проверка бумаг",
                        Text = "Проверить медицинские бумаги, касающиеся пациентов (договор на платное медицинское обслуживание)"
                    },
                    new Task()
                    {
                        Id = 2,
                        Num = 34534,
                        Location = "ГБУЗ «Городская поликлиника № 2», г. Улан-Удэ, ул. Каландарашвили, 27",
                        PeriodDateIn = new DateTime(2020, 7, 5),
                        PeriodDateOut = new DateTime(2020, 7, 10),
                        RemindTime = new DateTime(2020, 10, 10),
                        Priority = TaskPriority.Low,
                        Status = TaskStatus.InProgress,
                        Responsible = "Баиров Баир Баирович",
                        Title = "Проверка медицинской книжки",
                        Text = "Проверить наличие медицинской книжки у работников в соответствии с требованиями санитарно-гигиенических норм"
                    },
                    new Task()
                    {
                        Id = 3,
                        Num = 233,
                        Location = "ГБУЗ «Городская поликлиника № 3», г. Улан-Удэ, ул. Каландарашвили, 27",
                        PeriodDateIn = new DateTime(2020, 7, 5),
                        PeriodDateOut = new DateTime(2020, 7, 10),
                        RemindTime = new DateTime(2020, 10, 10),
                        Priority = TaskPriority.Medium,
                        Status = TaskStatus.Assigned,
                        Responsible = "Григорьев Михаил Дмитриевич",
                        Title = "Анализ санитарного состояния мест",
                        Text = "Сделать анализ санитарного состояния мест, где пища готовится и принимается"
                    },
                    new Task()
                    {
                        Id = 4,
                        Num = 34534,
                        Location = "ГБУЗ «Городская поликлиника № 2», г. Улан-Удэ, ул. Каландарашвили, 27",
                        PeriodDateIn = new DateTime(2020, 7, 5),
                        PeriodDateOut = new DateTime(2020, 7, 10),
                        RemindTime = new DateTime(2020, 10, 10),
                        Priority = TaskPriority.Low,
                        Status = TaskStatus.InProgress,
                        Responsible = "Баиров Баир Баирович",
                        Title = "Проверка медицинской книжки",
                        Text = "Проверить наличие медицинской книжки у работников в соответствии с требованиями санитарно-гигиенических норм"
                    },
                    new Task()
                    {
                        Id = 5,
                        Num = 233,
                        Location = "ГБУЗ «Городская поликлиника № 3», г. Улан-Удэ, ул. Каландарашвили, 27",
                        PeriodDateIn = new DateTime(2020, 7, 5),
                        PeriodDateOut = new DateTime(2020, 7, 10),
                        RemindTime = new DateTime(2020, 10, 10),
                        Priority = TaskPriority.Medium,
                        Status = TaskStatus.Assigned,
                        Responsible = "Григорьев Михаил Дмитриевич",
                        Title = "Анализ санитарного состояния мест",
                        Text = "Сделать анализ санитарного состояния мест, где пища готовится и принимается"
                    },
                    new Task()
                    {
                        Id = 6,
                        Num = 34534,
                        Location = "ГБУЗ «Городская поликлиника № 2», г. Улан-Удэ, ул. Каландарашвили, 27",
                        PeriodDateIn = new DateTime(2020, 7, 5),
                        PeriodDateOut = new DateTime(2020, 7, 10),
                        RemindTime = new DateTime(2020, 10, 10),
                        Priority = TaskPriority.Low,
                        Status = TaskStatus.InProgress,
                        Responsible = "Баиров Баир Баирович",
                        Title = "Проверка медицинской книжки",
                        Text = "Проверить наличие медицинской книжки у работников в соответствии с требованиями санитарно-гигиенических норм"
                    },
                    new Task()
                    {
                        Id = 7,
                        Num = 233,
                        Location = "ГБУЗ «Городская поликлиника № 3», г. Улан-Удэ, ул. Каландарашвили, 27",
                        PeriodDateIn = new DateTime(2020, 7, 5),
                        PeriodDateOut = new DateTime(2020, 7, 10),
                        RemindTime = new DateTime(2020, 10, 10),
                        Priority = TaskPriority.Medium,
                        Status = TaskStatus.Assigned,
                        Responsible = "Григорьев Михаил Дмитриевич",
                        Title = "Анализ санитарного состояния мест",
                        Text = "Сделать анализ санитарного состояния мест, где пища готовится и принимается"
                    }
                };
            }
        }
    }
}