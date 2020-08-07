using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class AuditOperationRecordViewModel
    {
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

        private void GenerateSource()
        {
            Num = "1";
            CompanyName = "ГБУЗ «Городская поликлиника № 1»";
            Address = "г. Улан-Удэ, ул. Каландарашвили, 27";
            TitleIndicator = "Отпуск и реализация лекарственных препаратов для медицинского применения в аптеке производственной (Приложение 23)";
            PeriodDateIn = new DateTime(2020, 5, 5);
            PeriodDateOut = new DateTime(2020, 5, 8);
        }
    }
}
