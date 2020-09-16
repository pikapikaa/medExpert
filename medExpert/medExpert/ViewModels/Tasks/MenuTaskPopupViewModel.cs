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
    public class MenuTaskPopupViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Команда для сортировки задач
        /// </summary>
        public ICommand SortTasksCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
            await PopupNavigation.Instance.PushAsync(new SortTasksPopupView());
        });

        /// <summary>
        /// Команда для фильтрации задач
        /// </summary>
        public ICommand FilterTasksCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
            await PopupNavigation.Instance.PushAsync(new FilterTasksPopupView());
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}