using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class AuditOperationRecordViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StructuralUnit> structuralUnits;
        public ObservableCollection<StructuralUnit> StructuralUnits
        {
            get { return structuralUnits; }
            set
            {
                structuralUnits = value;
                OnPropertyChanged();
            }
        }
        public string Num { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string TitleIndicator { get; set; }

        public DateTime PeriodDateIn { get; set; }

        public DateTime PeriodDateOut { get; set; }

        public string PeriodDateInText
        {
            get { return $"{PeriodDateIn:dd.MM.yyyy} г."; }
        }

        public string PeriodDateOutText
        {
            get { return $"{PeriodDateOut:dd.MM.yyyy} г."; }
        }

        public INavigation Navigation { get; set; }

        public AuditOperationRecordViewModel()
        {
            GenerateSource();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void GenerateSource()
        {
            Num = "1";
            CompanyName = "ГБУЗ «Городская поликлиника № 1»";
            Address = "г. Улан-Удэ, ул. Каландарашвили, 27";
            TitleIndicator = "Отпуск и реализация лекарственных препаратов для медицинского применения в аптеке производственной (Приложение 23)";
            PeriodDateIn = new DateTime(2020, 5, 5);
            PeriodDateOut = new DateTime(2020, 5, 8);

            var _listOfItems = new DataStructuralUnitFactory().GetData();
            StructuralUnits = new ObservableCollection<StructuralUnit>(_listOfItems);
        }
    }

    internal class DataStructuralUnitFactory
    {
        public List<StructuralUnit> GetData()
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
