using medExpert.Models;
using medExpert.Views.Audits;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class CheckListGroupsViewModel
    {
        private ObservableCollection<CheckList> checkListNodeInfo;
        
        public ObservableCollection<CheckList> CheckListNodeInfo
        {
            get { return checkListNodeInfo; }
            set { this.checkListNodeInfo = value; }
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

        public CheckListGroupsViewModel()
        {
            GenerateSource();
        }

        /// <summary>
        /// Команда открытия детального представления чек-листа
        /// </summary>
        public ICommand OpenCheckListDetailViewCommand => new Command<object>((object obj) =>
        {
            if (!(obj as Syncfusion.TreeView.Engine.TreeViewNode).HasChildNodes)
            {
                Navigation.PushAsync(new CheckListDetailView());
            }
        });

        /// <summary>
        /// Команда быстрого ответа на чек-лист
        /// </summary>
        public ICommand GiveQuickAnswerCommand => new Command<object>((object obj) =>
        {
            var res = (obj as CheckList).Name;
            var result = CheckListNodeInfo.Where(i => i.Name.Contains(res));
        });

        /// <summary>
        /// Команда открытия модального окна для одинакового выбора ответа
        /// </summary>
        public ICommand OpenSameAnswerPopup => new Command<object>(async (object obj) =>
        {
            //await PopupNavigation.Instance.PushAsync(new SameAnswerPopupView(), false);
        });

        /// <summary>
        /// Команда открытия окна для выбора структурного подразделения
        /// </summary>
        public ICommand OpenStructuralUnitsListView => new Command<object>(async (object obj) =>
        {
            await Navigation.PushModalAsync(new NavigationPage(new StructuralUnitsListView()), true);
        });

        private void GenerateSource()
        {
            var nodeImageInfo = new ObservableCollection<CheckList>();

            var check1 = new CheckList()
            {
                Name = "Уровень 1: Соблюдение осуществляющими медицинскую деятельность организациями и индивидуальными предпринимателями порядков проведения медицинских экспертиз, медицинских осмотров и медицинских освидетельствований (Приложение 3)",
            };

            var check1_level2 = new CheckList()
            {
                Name = "Уровень 2: Соблюдение медицинскими организациями и индивидуальными предпринимателями, осуществляющими медицинскую деятельность, порядка проведения судебно-медицинской экспертизы",
            };

            var check1_level2_1 = new CheckList()
            {
                Name = "Уровень 2: Соблюдение медицинскими организациями и индивидуальными предпринимателями, осуществляющими медицинскую деятельность, порядков проведения военно-врачебной экспертизы",
            };

            var check1_level3 = new CheckList()
            {
                Name = "Уровень 3: Имеется ли у государственного судебно-экспертного учреждения (далее - ГСЭУ) лицензия на осуществление медицинской деятельности по соответствующим работам (услугам) (судебно-медицинская экспертиза)?",
            };

            var check1_level3_1 = new CheckList()
            {
                Name = "Уровень 3: Соответствует ли штатное расписание ГСЭУ требованиям, установленным для соответствующих медицинских организаций (структурных подразделений)?",
                AnswerType = AnswerType.Yes,
            };

            var check1_level3_2 = new CheckList()
            {
                Name = "Уровень 3: Соблюдаются ли квалификационные требования к образованию и занимаемой должности эксперта ГСЭУ с целью производства судебной экспертизы?",
                AnswerType = AnswerType.InApplicable,
            };

            var check1_level3_3 = new CheckList()
            {
                Name = "Уровень 3: Порядок действий персонала при чрезвычайных ситуациях",
                AnswerType = AnswerType.No,
            };

            var check1_level3_4 = new CheckList()
            {
                Name = "Уровень 3: Имеется ли у государственного судебно-экспертного учреждения (далее - ГСЭУ) лицензия на осуществление медицинской деятельности по соответствующим работам (услугам) (судебно-медицинская экспертиза)?",
            };

            var check1_level3_5 = new CheckList()
            {
                Name = "Уровень 3: Соответствует ли штатное расписание ГСЭУ требованиям, установленным для соответствующих медицинских организаций (структурных подразделений)?",
                AnswerType = AnswerType.Yes,
            };

            var check1_level3_6 = new CheckList()
            {
                Name = "Уровень 3: Соблюдаются ли квалификационные требования к образованию и занимаемой должности эксперта ГСЭУ с целью производства судебной экспертизы?",
                AnswerType = AnswerType.InApplicable,
            };

            var check1_level3_7 = new CheckList()
            {
                Name = "Уровень 3: Порядок действий персонала при чрезвычайных ситуациях",
                AnswerType = AnswerType.No,
            };

            var check2 = new CheckList()
            {
                Name = "Уровень 1: ОРГАНИЗАЦИЯ ПРОФИЛАКТИЧЕСКОЙ РАБОТЫ. ФОРМИРОВАНИЕ ЗДОРОВОГО ОБРАЗА ЖИЗНИ СРЕДИ НАСЕЛЕНИЯ",
            };

            var check2_level2 = new CheckList()
            {
                Name = "Организация работы профилактического отделения, мероприятий по формированию здорового образа жизни",
            };

            var check2_level3 = new CheckList()
            {
                Name = "Наличие приказов главного врача включая определение отвественных, комиссии, рабочей группы  по:",
            };

            var check2_level3_1 = new CheckList()
            {
                Name = "Наличие ведомственных,  региональных приказов",
                AnswerType = AnswerType.InApplicable,
            };

            var check2_level3_2 = new CheckList()
            {
                Name = "Наличие приказов главного врача по организации работы Центра медицинской профилактики (если применимо)",
                AnswerType = AnswerType.Yes,
            };

            var check2_level3_3 = new CheckList()
            {
                Name = "Проведение регулярного аудита мероприятий профилактики хронических неинфекционных заболеваний",
                AnswerType = AnswerType.No,
            };

            var check2_level4 = new CheckList()
            {
                Name = "наличие национального календаря от текущего года;",
                AnswerType = AnswerType.InApplicable,
            };

            var check2_level4_1 = new CheckList()
            {
                Name = "наличие плана мероприятий МО вовлечения прикрепленного населения к проведению вакцинации на текущий год.",
                AnswerType = AnswerType.No,
            };

            check1.SubCheckLists = new ObservableCollection<CheckList>
            {
                check1_level2,
                check1_level2_1
            };

            check1_level2.SubCheckLists = new ObservableCollection<CheckList>
            {
                check1_level3,
                check1_level3_1,
                check1_level3_2,
                check1_level3_3,
            };

            check1_level2_1.SubCheckLists = new ObservableCollection<CheckList>
            {
                check1_level3_4,
                check1_level3_5,
                check1_level3_6,
                check1_level3_7,
            };

            check2.SubCheckLists = new ObservableCollection<CheckList>
            {
                check2_level2,
            };

            check2_level2.SubCheckLists = new ObservableCollection<CheckList>
            {
                check2_level3,
                check2_level3_1,
                check2_level3_2,
                check2_level3_3,
            };

            check2_level3.SubCheckLists = new ObservableCollection<CheckList>
            {
                check2_level4,
                check2_level4_1
            };

            nodeImageInfo.Add(check1);
            nodeImageInfo.Add(check2);

            checkListNodeInfo = nodeImageInfo;
            Num = "1";
            CompanyName = "ГБУЗ «Городская поликлиника № 1»";
            Address = "г. Улан-Удэ, ул. Каландарашвили, 27";
            TitleIndicator = "Отпуск и реализация лекарственных препаратов для медицинского применения в аптеке производственной (Приложение 23)";
            PeriodDateIn = new DateTime(2020, 5, 5);
            PeriodDateOut = new DateTime(2020, 5, 8);
        }
    }
}
