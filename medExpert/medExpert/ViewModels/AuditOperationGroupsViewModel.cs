using medExpert.Views.Audits;
using medExpert.Views.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medExpert.ViewModels
{
    class AuditOperationGroupsViewModel
    {
        public ICommand OpenAddAuditPageCommand { protected set; get; }
        public ICommand OpenAllAuditsPageCommand { protected set; get; }

        public INavigation Navigation { get; set; }
        public AuditOperationGroupsViewModel()
        {
            OpenAddAuditPageCommand = new Command(OpenAddAuditPage);
            OpenAllAuditsPageCommand = new Command(OpenAllAuditsPage);
        }

        /// <summary>
        /// Команда выбора всех проверок
        /// </summary>
        /// <param name="obj"></param>
        private void OpenAllAuditsPage(object obj)
        {
            Navigation.PushAsync(new AuditListView());
        }

        /// <summary>
        /// Команда открытия экрана для добаления новой проверки
        /// </summary>
        private void OpenAddAuditPage()
        {
            Navigation.PushAsync(new BlablablaView());
        }
    }
}