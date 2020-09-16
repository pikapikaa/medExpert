using medExpert.Models;
using medExpert.Views.Audits;
using medExpert.Views.Mock;
using medExpert.Views.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace medExpert.Navigation
{
    class MedExpertMasterDetailPage : MasterDetailPage
    {
        public MedExpertMasterDetailPage()
        {
            var master = new MenuPage();
            if (Device.RuntimePlatform == Device.iOS)
            {
                master.IconImageSource = ImageSource.FromFile("nav-menu-icon");
            }
            master.PageSelected += OnPageSelected;

            this.Master = master;
            this.MasterBehavior = MasterBehavior.Popover;

            OnPageSelected(null, PageType.Tasks);
        }
        private void OnPageSelected(object e, PageType pageType)
        {
            Page page;

            switch (pageType)
            {
                case PageType.Audits:
                    page = new AuditOperationGroupsView();
                    break;
                case PageType.Tasks:
                    page = new TasksView();
                    break;
                case PageType.Projects:
                case PageType.Profile:
                case PageType.Settings:
                case PageType.Updating:
                default:
                    page = new BlablablaView();
                    break;
            }

            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}
