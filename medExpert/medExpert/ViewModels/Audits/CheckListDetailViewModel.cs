using medExpert.Models;
using medExpert.Views.Audits.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace medExpert.ViewModels.Audits
{
    public class CheckListDetailViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Violation> violations;
        public ObservableCollection<Violation> Violations
        {
            get { return violations; }
            set
            {
                violations = value;
                OnPropertyChanged(nameof(Violations));
            }
        }

        public CheckListDetailViewModel()
        {
            var _listOfItems = new DataViolationFactory().GetViolations();
            Violations = new ObservableCollection<Violation>(_listOfItems);
            //GenerateSource();
        }

        public DashPattern BorderDashPattern { get; set; } = new DashPattern(10, 5, 2, 5);

        /// <summary>
        /// 
        /// </summary>
        public ICommand ShowMenuViolation => new Command<object>(async (object obj) =>
        {
            await PopupNavigation.Instance.PushAsync(new MenuPopupView(), false);
        });

        /// <summary>
        /// 
        /// </summary>
        public ICommand CheckViolationCommand => new Command<object>((object obj) =>
        {

        });

        /// <summary>
        /// Команда быстрого ответа на чек-лист
        /// </summary>
        public ICommand InverseAccordion => new Command<object>((object obj) =>
        {
            var item = (obj as SwipeView).BindingContext as Violation;
            item.IsExpand = !item.IsExpand;
        });

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void GenerateSource()
        {
            var nodeImageInfo = new ObservableCollection<Violation>();

            var check1 = new Violation()
            {
                Id = 1,
                Text = "Не отпускаются наркотические и психотропные препараты по рецептам"
            };

            var check1_level2 = new Violation()
            {
                Id = 1,
                Text = "Не отпускаются наркотические и психотропные препараты по рецептам2"
            };

            var check1_level2_1 = new Violation()
            {
                Id = 1,
                Text = "Не отпускаются наркотические и психотропные препараты по рецептам3"
            };



            var check2 = new Violation()
            {
                Id = 1,
                Text = "Не отпускаются наркотические и психотропные препараты по рецептам4"
            };

            var check2_level2 = new Violation()
            {
                Id = 1,
                Text = "Не отпускаются наркотические и психотропные препараты по рецептам5"
            };





            check1.SubViolations = new ObservableCollection<Violation>
            {
                check1_level2,
                check1_level2_1
            };



            check2.SubViolations = new ObservableCollection<Violation>
            {
                check2_level2,
            };

            nodeImageInfo.Add(check1);
            nodeImageInfo.Add(check2);

            violations = nodeImageInfo;
        }
    }

    internal class DataViolationFactory
    {
        public List<Violation> GetViolations()
        {
            return new List<Violation>()
            {
                new Violation()
                {
                    Id = 1,
                    Text = "Не отпускаются наркотические и психотропные препараты по рецептам"
                },
                 new Violation()
                {
                    Id = 2,
                    Text = "Не отпускаются наркотические и психотропные препараты по рецептам2"
                },
                  new Violation()
                {
                    Id = 3,
                    Text = "Не отпускаются наркотические и психотропные препараты по рецептам3"
                }
            };
        }
    }


}