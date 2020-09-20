using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace medExpert.ViewModels.Tasks
{
    public class TaskDetailViewModel : INotifyPropertyChanged
    {
        private string title;
        private string text;
        private string responsible;
        private string expiration;

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        /// <summary>
        /// Содержимое задачи
        /// </summary>
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        /// <summary>
        /// Ответственный за выполнение
        /// </summary>
        public string Responsible
        {
            get => responsible;
            set
            {
                responsible = value;
                OnPropertyChanged(nameof(Responsible));
            }
        }

        /// <summary>
        /// Срок выполнения задачи
        /// </summary>
        public string Expiration
        {
            get => expiration;
            set
            {
                expiration = value;
                OnPropertyChanged(nameof(Expiration));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}