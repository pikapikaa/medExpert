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
    public class FilterTasksPopupViewModel : INotifyPropertyChanged
    {
        private bool isAllPriority = true;
        private bool isLowPriority = false;
        private bool isMediumPriority = false;

        /// <summary>
        /// Признак выбора приоритета All
        /// </summary>
        public bool IsAllPriority
        {
            get { return isAllPriority; }
            set
            {
                isAllPriority = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Признак выбора приоритета Low
        /// </summary>
        public bool IsLowPriority
        {
            get { return isLowPriority; }
            set
            {
                isLowPriority = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Признак выбора приоритета Medium
        /// </summary>
        public bool IsMediumPriority
        {
            get { return isMediumPriority; }
            set
            {
                isMediumPriority = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда выбора приоритета Low
        /// </summary>
        public ICommand ClickLowPriorityCommand => new Command(() =>
        {
            IsLowPriority = true;
            IsMediumPriority = false;
            IsAllPriority = false;
        });

        /// <summary>
        /// Команда выбора приоритета Medium
        /// </summary>
        public ICommand ClickMediumPriorityCommand => new Command(() =>
        {
            IsLowPriority = false;
            IsMediumPriority = true;
            IsAllPriority = false;
        });

        /// <summary>
        /// Команда выбора приоритета All
        /// </summary>
        public ICommand ClickAllPriorityCommand => new Command(() =>
        {
            IsLowPriority = false;
            IsMediumPriority = false;
            IsAllPriority = true;
        });

        /// <summary>
        /// Команда закрытия попап
        /// </summary>
        public ICommand CloseSortFilterTasksPopupViewCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
        });

        /// <summary>
        /// Команда нажатия кнопки "Применить фильтр"
        /// </summary>
        public ICommand FilterTasksCommand => new Command(async () =>
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