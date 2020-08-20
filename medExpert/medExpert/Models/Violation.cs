using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace medExpert.Models
{
    public class Violation : INotifyPropertyChanged
    {
        private ObservableCollection<Recommendation> recommendations;
        private bool isExpand;
        private bool isChecked;
       
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (value != this.isChecked)
                {
                    this.isChecked = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsExpand
        {
            get { return isExpand; }
            set
            {
                isExpand = value;
                OnPropertyChanged();
            }
        }
        public int Id { get; set; }

        public string Text { get; set; }

        public ObservableCollection<Recommendation> Recommendations
        {
            get { return recommendations; }
            set
            {
                recommendations = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
