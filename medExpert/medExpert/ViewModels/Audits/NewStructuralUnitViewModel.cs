using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class NewStructuralUnitViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation;
        private string _nameStructuralUnit = "";

        public string NameStructuralUnit
        {
            get { return _nameStructuralUnit; }
            set
            {
                _nameStructuralUnit = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Команда для закрытия текущего экрана
        /// </summary>
        public ICommand CloseNewStructuralUnitViewCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });

        /// <summary>
        /// Команда создания нового подразделения
        /// </summary>
        public ICommand AddNewStructuralUnitCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });

        public ICommand SearchTextChangedCommand => new Command(async () =>
        {
            if (string.IsNullOrWhiteSpace(NameStructuralUnit))
            {

            }
            else
            {

            }
        });

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
