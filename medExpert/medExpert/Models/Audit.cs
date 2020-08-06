using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace medExpert.Models
{
    /// <summary>
    /// Модель записи операции аудита
    /// </summary>
    public class Audit : INotifyPropertyChanged
    {
        private List<Indicator> _indicatorLists = new List<Indicator>();

        public int Id { get; set; }

        public int Num { get; set; }

        public string Location { get; set; }

        /// <summary>Начало периода операции аудита</summary>
        public DateTime PeriodDateIn { get; set; }

        /// <summary>Окончание периода операции аудита</summary>
        public DateTime PeriodDateOut { get; set; }

        /// <summary>Язык и региональне парамметрв</summary>
        private CultureInfo Culture { get; set; } = new CultureInfo("ru", false);

        /// <summary>
        /// Текстовое представление начала периода операции аудита
        /// </summary>
        public string PeriodDateInText
        {
            get { return $"{PeriodDateIn:dd.MM.yyyy} г."; }
        }

        /// <summary>
        /// Текстовое представление окончания периода операции аудита
        /// </summary>
        public string PeriodDateOutText
        {
            get { return $"{PeriodDateOut:dd.MM.yyyy} г."; }
        }

        public List<Indicator> IndicatorLists
        {
            get { return _indicatorLists; }
            set
            {
                _indicatorLists = value;
                OnChanged(nameof(IndicatorLists));
                OnChanged(nameof(IndicatorListHeight));
            }
        }

        public double IndicatorListHeight
        {
            get { return IndicatorLists.Count * 50; }
        }

        public AuditOperationStatus Status { get; set; }

        protected void OnChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
