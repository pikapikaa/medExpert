using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace medExpert.Models
{
    /// <summary>
    /// Модель задачи
    /// </summary>
    public class Task : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public int Num { get; set; }

        public string Location { get; set; }

        /// <summary>
        /// Приоритет
        /// </summary>
        public TaskPriority Priority { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Ответственный за выполнение
        /// </summary>
        public string Responsible { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст задачи
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Время напоминания о задаче
        /// </summary>
        public DateTime RemindTime { get; set; }

        /// <summary>Начало выполнения задачи</summary>
        public DateTime PeriodDateIn { get; set; }

        /// <summary>Окончание выполнения задачи</summary>
        public DateTime PeriodDateOut { get; set; }

        /// <summary>
        /// Текстовое представление начала выполнения задачи
        /// </summary>
        public string PeriodDateInText
        {
            get { return $"{PeriodDateIn:dd.MM.yyyy} г."; }
        }

        /// <summary>
        /// Текстовое представление окончания выполнения задачи
        /// </summary>
        public string PeriodDateOutText
        {
            get { return $"{PeriodDateOut:dd.MM.yyyy} г."; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}