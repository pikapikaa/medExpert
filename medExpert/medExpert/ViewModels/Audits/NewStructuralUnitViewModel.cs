using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels.Audits
{
    public class NewStructuralUnitViewModel
    {
        public INavigation Navigation;

        /// <summary>
        /// Команда для закрытия текущего экрана
        /// </summary>
        public ICommand CloseNewStructuralUnitViewCommand => new Command(async () =>
        {
            await Navigation.PopModalAsync();
        });
    }
}
