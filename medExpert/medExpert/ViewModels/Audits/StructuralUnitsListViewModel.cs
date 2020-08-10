using medExpert.Models;
using medExpert.Views.Audits.Popups;
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

namespace medExpert.ViewModels.Audits
{
    class StructuralUnitsListViewModel : INotifyPropertyChanged
    {
        private bool isEntryVisible = false;
        private string searchText = "";
        public INavigation Navigation { get; set; }
        private ObservableCollection<StructuralUnit> structuralUnits =
           new ObservableCollection<StructuralUnit>();

        private ObservableCollection<StructuralUnit> _structuralUnitsFiltered;
        private ObservableCollection<StructuralUnit> _structuralUnitsUnfiltered;

        public ObservableCollection<StructuralUnit> StructuralUnits
        {
            get { return structuralUnits; }
            set
            {
                structuralUnits = value;
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

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StructuralUnits));
            }
        }

        public StructuralUnitsListViewModel()
        {
            var _listOfItems = new DataFactory().GetStructuralUnits();
            StructuralUnits = new ObservableCollection<StructuralUnit>(_listOfItems);
            _structuralUnitsUnfiltered = new ObservableCollection<StructuralUnit>(_listOfItems);

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
                 MessageKeys.AscendingSort, sender =>
                 {
                     _structuralUnitsFiltered = new ObservableCollection<StructuralUnit>(_structuralUnitsUnfiltered
                                           .OrderBy(t => t.Name));
                     StructuralUnits = _structuralUnitsFiltered;
                 });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
               MessageKeys.DescendingSort, sender =>
               {
                   _structuralUnitsFiltered = new ObservableCollection<StructuralUnit>(_structuralUnitsUnfiltered
                                         .OrderByDescending(t => t.Name));
                   StructuralUnits = _structuralUnitsFiltered;
               });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
               MessageKeys.DefaultSort, sender =>
               {
                   StructuralUnits = _structuralUnitsFiltered;
               });

            MessagingCenter.Subscribe<SortPopupViewModel>(this,
             MessageKeys.DateSort, sender =>
             {
                 StructuralUnits = _structuralUnitsFiltered;
             });
        }

        /// <summary>
        /// Команда закрытия текущего экрана
        /// </summary>
        public ICommand CloseStructuralUnitsListViewCommand => new Command<object>(async (object obj) =>
        {
            await Navigation.PopModalAsync();
        });

        /// <summary>
        /// Команда добавления подразделения
        /// </summary>
        public ICommand AddStructuralUnitCommand => new Command<object>(async (object obj) =>
        {
            MessagingCenter.Send(this, MessageKeys.AddStructuralUnit);
            await Navigation.PopModalAsync();
        });

        /// <summary>
        /// 
        /// </summary>
        public ICommand ClickCheckBoxCommand => new Command<object>(async(object obj) =>
        {
            if (obj is StructuralUnit  structuralUnit)
            {
                var item = StructuralUnits.FirstOrDefault(i => i.Id == structuralUnit.Id);
                if (item != null)
                {
                    item.IsChecked = !item.IsChecked;
                }
            }
            OnPropertyChanged();
        });

        /// <summary>
        /// Команда поиска структурного подразделения
        /// </summary>
        public ICommand SearchTextChangedCommand => new Command(() =>
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                StructuralUnits = _structuralUnitsUnfiltered;
            else
            {
                _structuralUnitsFiltered = new ObservableCollection<StructuralUnit>(_structuralUnitsUnfiltered
                                            .Where(i => (i is StructuralUnit && (((StructuralUnit)i)
                                            .Name.ToLower()
                                            .Contains(SearchText.ToLower())))));
                StructuralUnits = _structuralUnitsFiltered;
            }
        });

        /// <summary>
        /// Команда показа строки поиска структурного подразделения
        /// </summary>
        public ICommand ShowSearchEntryCommand => new Command(() =>
        {
            IsEntryVisible = !IsEntryVisible;
        });

        /// <summary>
        /// Команда открытия окна меню
        /// </summary>
        public ICommand OpenMenuPopupCommand => new Command(async () =>
        {
            IsEntryVisible = false;
            await PopupNavigation.Instance.PushAsync(new MenuPopupView(), false);
        });

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    internal class DataFactory
    {
        public List<StructuralUnit> GetStructuralUnits()
        {
            return new List<StructuralUnit>()
            {
                new StructuralUnit(){Id=1,Name = "Республиканская клиническая больница скорой медицинской помощи им. В.В. Ангапова"},
                new StructuralUnit(){Id=2,Name = "Детская республиканская клиническая больница"},
                new StructuralUnit(){Id=3,Name = "Республиканская клиническая инфекционная больница"},
                new StructuralUnit(){Id=4, Name = "РЖД-МЕДИЦИНА, клиническая больница"},
                new StructuralUnit(){Id=5,Name = "Городская поликлиника №5, Городская больница №5"},
                new StructuralUnit(){Id=6, Name = "Городская поликлиника №1, Городская больница №1"},
                new StructuralUnit(){Id=7,Name = "Городская поликлиника №2, Городская больница №2"},
                new StructuralUnit(){Id=8, Name = "Городская поликлиника №3, Городская больница №3"},
                new StructuralUnit(){Id=9,Name = "Городская поликлиника №4, Городская больница №4"},
                new StructuralUnit(){Id=10, Name = "Городская поликлиника №6, Городская больница №6"},
                new StructuralUnit(){Id=11,Name = "Республиканский перинатальный центр Министерства здравоохранения Республики Бурятия"},
                new StructuralUnit(){Id=12, Name = "Республиканская клиническая больница им. Н.А. Семашко"},
                new StructuralUnit(){Id=13,Name = "Иволгинская центральная районная больница"},
                new StructuralUnit(){Id=14, Name = "Ильинская участковая больница"},

            };
        }
    }
}