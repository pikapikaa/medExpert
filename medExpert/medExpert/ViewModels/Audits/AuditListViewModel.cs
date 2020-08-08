using medExpert.Models;
using medExpert.Views.Audits;
using medExpert.Views.Mock;
using Rg.Plugins.Popup.Services;
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
    class AuditListViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        private ObservableCollection<Audit> audits;
        public ObservableCollection<Audit> Audits
        {
            get { return audits; }
            set
            {
                audits = value;
                OnPropertyChanged(nameof(Audits));
            }
        }

        public AuditListViewModel()
        {
            var _listOfItems = new DataAuditFactory().GetAudits();
            Audits = new ObservableCollection<Audit>(_listOfItems);
        }

        /// <summary>
        /// Команда выбора меню
        /// </summary>
        public ICommand SelectToolbar => new Command(async () =>
        {
            //await PopupNavigation.Instance.PushAsync(new BlablablaView(), false);
        });

        /// <summary>
        /// Команда 
        /// </summary>
        public ICommand OpenCheckListGroupCommand => new Command<object>(async (object list) =>
        {
            var flag = (list as Indicator)?.AuditType;

            switch (flag)
            {
                case AuditType.Employee:
                case AuditType.StructuralUnit:
                    await Navigation.PushAsync(new AuditOperationRecordView());
                    return;
                case AuditType.Default:
                    await Navigation.PushAsync(new CheckListGroupsView());
                    return;
                default:
                    return;
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        internal class DataAuditFactory
        {
            public List<Audit> GetAudits()
            {
                return new List<Audit>()
            {
                new Audit(){
                    Id=1,
                    Num=443,
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,7,5),
                    PeriodDateOut=new DateTime(2020,7,10),
                    Status = AuditOperationStatus.Created,
                    IndicatorLists = new List<Indicator>{
                          new Indicator()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан",
                            AuditType = AuditType.Employee
                        },
                        new Indicator()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Проверка кабинетов, в том числе соблюдение условий хранения ЛС и МИ",
                            AuditType = AuditType.Default
                        },
                        new Indicator()
                        {
                            Id=3,
                            Auditor=null,
                            IsChecked=false,
                            Name="Размещение информации на информационных стендах и сайте организации",
                            AuditType = AuditType.StructuralUnit
                        },
                    } },
                new Audit(){
                    Id=2,
                    Num=24,
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,5,5),
                    PeriodDateOut=new DateTime(2020,5,8),
                    Status = AuditOperationStatus.Executed,
                    IndicatorLists = new List<Indicator>{
                        new Indicator()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан",
                            AuditType = AuditType.StructuralUnit
                        },
                        new Indicator()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав пациентов",
                            AuditType = AuditType.StructuralUnit
                        },
                    } },
                 new Audit(){
                    Id=3,
                    Num=56,
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,7,1),
                    PeriodDateOut=new DateTime(2020,7,5),
                    Status = AuditOperationStatus.Running,
                    IndicatorLists = new List<Indicator>{
                        new Indicator()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан",
                            AuditType = AuditType.Employee
                        },
                        new Indicator()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Проверка кабинетов, в том числе соблюдение условий хранения ЛС и МИ",
                            AuditType = AuditType.StructuralUnit
                        },
                        new Indicator()
                        {
                            Id=3,
                            Auditor=null,
                            IsChecked=false,
                            Name="Размещение информации на информационных стендах и сайте организации",
                            AuditType = AuditType.Default
                        },
                    } },
                 new Audit(){
                    Id=4,
                    Num=57,
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,7,16),
                    PeriodDateOut=new DateTime(2020,7,27),
                    Status = AuditOperationStatus.Signed,
                    IndicatorLists = new List<Indicator>{
                        new Indicator()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан",
                            AuditType = AuditType.StructuralUnit
                        },
                        new Indicator()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав пациентов",
                            AuditType = AuditType.Employee
                        },
                    } },
                new Audit(){
                    Id=5,
                    Num=38,
                    Location="ГБУЗ «Городская поликлиника № 1», г. Улан-Удэ, ул. Каландарашвили, 27",
                    PeriodDateIn=new DateTime(2020,6,5),
                    PeriodDateOut=new DateTime(2020,6,15),
                    Status = AuditOperationStatus.Signing,
                    IndicatorLists = new List<Indicator>{
                         new Indicator()
                        {
                            Id=1,
                            Auditor=null,
                            IsChecked=false,
                            Name="Соблюдение прав граждан",
                            AuditType = AuditType.Employee
                        },
                        new Indicator()
                        {
                            Id=2,
                            Auditor=null,
                            IsChecked=false,
                            Name="Проверка кабинетов, в том числе соблюдение условий хранения ЛС и МИ",
                            AuditType = AuditType.StructuralUnit
                        },
                        new Indicator()
                        {
                            Id=3,
                            Auditor=null,
                            IsChecked=false,
                            Name="Размещение информации на информационных стендах и сайте организации",
                            AuditType = AuditType.Default
                        },
                    } }


            };
            }
        }
    }
}
