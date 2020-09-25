using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class SortTasksPopupViewModel : INotifyPropertyChanged
    {
        private bool isAscendingSort = true;
        private bool isDescendingSort = false;

        /// <summary>
        /// Признак выбора сортировки по возрастанию
        /// </summary>
        public bool IsAscendingSort
        {
            get { return isAscendingSort; }
            set
            {
                isAscendingSort = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Признак выбора сортировки по убыванию
        /// </summary>
        public bool IsDescendingSort
        {
            get { return isDescendingSort; }
            set
            {
                isDescendingSort = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда выбора сортировки по возрастанию
        /// </summary>
        public ICommand ClickAscendingSortCommand => new Command(() =>
        {
            IsAscendingSort = true;
            IsDescendingSort = false;
        });

        /// <summary>
        /// Команда выбора сортировки по убыванию
        /// </summary>
        public ICommand ClickDescendingSortCommand => new Command(() =>
        {
            IsAscendingSort = false;
            IsDescendingSort = true;
        });

        /// <summary>
        /// Команда нажатия кнопки "Сортировать"
        /// </summary>
        public ICommand CloseSortTasksPopupViewCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
        });

        /// <summary>
        /// Команда нажатия кнопки "Сортировать"
        /// </summary>
        public ICommand ClickSortButtonCommand => new Command(async () =>
        {
            //if (IsAscendingSort)
            //{
            //    MessagingCenter.Send(this, MessageKeys.AscendingSort);
            //}
            //else if (IsDescendingSort)
            //{
            //    MessagingCenter.Send(this, MessageKeys.DescendingSort);
            //}
            //else if (IsDateSort)
            //{
            //    MessagingCenter.Send(this, MessageKeys.DateSort);
            //}
            //else if (IsDefaultSort)
            //{
            //    MessagingCenter.Send(this, MessageKeys.DefaultSort);
            //}
            await PopupNavigation.Instance.PopAsync();
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
