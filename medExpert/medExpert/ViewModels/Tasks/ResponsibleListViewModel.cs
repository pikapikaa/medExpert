using medExpert.Models;
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

namespace medExpert.ViewModels.Tasks
{
    public class ResponsibleListViewModel : INotifyPropertyChanged
    {
        private bool isEntryVisible = false;
        private string searchText = "";
        private bool isNewTask = false;
        public INavigation Navigation { get; set; }
        private ObservableCollection<Employee> employees =
           new ObservableCollection<Employee>();

        private ObservableCollection<Employee> _employeesFiltered;
        private ObservableCollection<Employee> _employeesUnfiltered;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }

        public bool IsEntryVisible
        {
            get { return isEntryVisible; }
            set
            {
                isEntryVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsNewTask
        {
            get { return isNewTask; }
            set
            {
                isNewTask = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Employees));
            }
        }

        public ResponsibleListViewModel()
        {
            var _listOfItems = new DataResponsibleFactory().GetEmployees();
            Employees = new ObservableCollection<Employee>(_listOfItems);
            _employeesUnfiltered = new ObservableCollection<Employee>(_listOfItems);

            //MessagingCenter.Subscribe<SortPopupViewModel>(this,
            //     MessageKeys.AscendingSort, sender =>
            //     {
            //         _structuralUnitsFiltered = new ObservableCollection<StructuralUnit>(_structuralUnitsUnfiltered
            //                               .OrderBy(t => t.Name));
            //         StructuralUnits = _structuralUnitsFiltered;
            //     });

            //MessagingCenter.Subscribe<SortPopupViewModel>(this,
            //   MessageKeys.DescendingSort, sender =>
            //   {
            //       _structuralUnitsFiltered = new ObservableCollection<StructuralUnit>(_structuralUnitsUnfiltered
            //                             .OrderByDescending(t => t.Name));
            //       StructuralUnits = _structuralUnitsFiltered;
            //   });

            //MessagingCenter.Subscribe<SortPopupViewModel>(this,
            //   MessageKeys.DefaultSort, sender =>
            //   {
            //       StructuralUnits = _structuralUnitsFiltered;
            //   });

            //MessagingCenter.Subscribe<SortPopupViewModel>(this,
            // MessageKeys.DateSort, sender =>
            // {
            //     StructuralUnits = _structuralUnitsFiltered;
            // });
        }

        /// <summary>
        /// Команда закрытия попап окна
        /// </summary>
        public ICommand ClosePopupCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });

        /// <summary>
        /// Команда поиска структурного подразделения
        /// </summary>
        public ICommand SearchTextChangedCommand => new Command(() =>
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                Employees = _employeesUnfiltered;
            else
            {
                _employeesFiltered = new ObservableCollection<Employee>(_employeesUnfiltered
                                            .Where(i => (i is Employee && (((Employee)i)
                                            .FullName.ToLower()
                                            .Contains(SearchText.ToLower())))));
                Employees = _employeesFiltered;
            }
        });

        public ICommand ClickCheckBoxCommand => new Command<object>((object obj) =>
        {
            if (obj is Employee structuralUnit)
            {
                var item = Employees.FirstOrDefault(i => i.Id == structuralUnit.Id);
                if (item != null)
                {
                    Employees.ToList().ForEach(c => c.IsChecked = false);
                    item.IsChecked = true;
                }
            }
            OnPropertyChanged(nameof(Employees));
        });

        /// <summary>
        /// Команда показа строки поиска структурного подразделения
        /// </summary>
        public ICommand ShowSearchEntryCommand => new Command(() =>
        {
            IsEntryVisible = !IsEntryVisible;
        });

        /// <summary>
        /// Команда добавления сотрудника
        /// </summary>
        public ICommand AddEmployeeCommand => new Command<object>(async (object obj) =>
        {
            var item = Employees.FirstOrDefault(i => i.IsChecked);
            if (item != null)
            {
                if (!IsNewTask)
                {
                    MessagingCenter.Send(item, MessageKeys.AddResponsible);
                }
                else
                {
                    MessagingCenter.Send(item, MessageKeys.AddResponsibleToNewTask);
                }
            }
            await Navigation.PopModalAsync();
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal class DataResponsibleFactory
        {
            public List<Employee> GetEmployees()
            {
                return new List<Employee>()
            {
                new Employee(){Id=1,FullName = "Будаев Батожаб Надмит-Цыренович"},
                new Employee(){Id=2,FullName = "Бадмаев Бадма Бадмаевич"},
                new Employee(){Id=3,FullName = "Юрьев Юрий Юрьевич"},
                new Employee(){Id=4, FullName = "Ivanov Ivan Ivanovich"},
                new Employee(){Id=5,FullName = "Будаев Батожаб Надмит-Цыренович"},
                new Employee(){Id=6, FullName = "Бадмаев Бадма Бадмаевич"},
                new Employee(){Id=7,FullName = "Юрьев Юрий Юрьевич"},
                new Employee(){Id=8, FullName = "Бадмаев Бадма Бадмаевич"},
                new Employee(){Id=9,FullName = "Будаев Батожаб Надмит-Цыренович"},
                new Employee(){Id=10, FullName = "Бадмаев Бадма Бадмаевич"},
                new Employee(){Id=11,FullName = "Юрьев Юрий Юрьевич"},
                new Employee(){Id=12, FullName = "Будаев Батожаб Надмит-Цыренович"},
                new Employee(){Id=13,FullName = "Бадмаев Бадма Бадмаевич"},
                new Employee(){Id=14, FullName = "Будаев Батожаб Надмит-Цыренович"},

            };
            }
        }
    }
}