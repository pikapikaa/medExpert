using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace medExpert.Models
{
    public class CheckList : INotifyPropertyChanged
    {
        private AnswerType answerType;
        private ObservableCollection<CheckList> subCheckLists;

        public bool IsLast { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        private Employee auditor;

        /// <summary>
        /// Аудитор
        /// </summary>
        public Employee Auditor
        {
            get { return auditor; }
            set
            {
                if (value != auditor)
                {
                    auditor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Коллекция вложенных чек-листов
        /// </summary>
        public ObservableCollection<CheckList> SubCheckLists
        {
            get { return subCheckLists; }
            set
            {
                subCheckLists = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Тип ответа
        /// </summary>
        public AnswerType AnswerType
        {
            get { return answerType; }
            set
            {
                answerType = value;
                NotifyPropertyChanged();
            }
        }

        private bool isChecked;

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (value != this.isChecked)
                {
                    this.isChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}