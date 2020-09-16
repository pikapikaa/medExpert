using medExpert.Models;
using medExpert.Views.Tasks;
using medExpert.Views.Tasks.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private ObservableCollection<Audit> audits;
        public ObservableCollection<Audit> Tasks
        {
            get { return audits; }
            set
            {
                audits = value;
                OnPropertyChanged(nameof(Audits));
            }
        }

        public TasksViewModel()
        {
            var _listOfItems = new DataAuditFactory().GetAudits();
            Tasks = new ObservableCollection<Audit>(_listOfItems);
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
        public ICommand OpenTaskDetailCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new TaskDetailView());
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}