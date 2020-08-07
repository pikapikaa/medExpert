using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    class StructuralUnitsListViewModel : INotifyPropertyChanged
    {
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

        public StructuralUnitsListViewModel()
        {
            var _listOfItems = new DataFactory().GetStructuralUnits();
            StructuralUnits = new ObservableCollection<StructuralUnit>(_listOfItems);
            _structuralUnitsUnfiltered = new ObservableCollection<StructuralUnit>(_listOfItems);
        }

        /// <summary>
        /// Команда закрытия текущего экрана
        /// </summary>
        public ICommand CloseStructuralUnitsListViewCommand => new Command<object>(async (object obj) =>
        {
            await Navigation.PopModalAsync();
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