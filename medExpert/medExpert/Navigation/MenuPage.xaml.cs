using medExpert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace medExpert.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public event EventHandler<PageType> PageSelected;
        public MenuPage()
        {
            InitializeComponent();
            btnAudits.GestureRecognizers.Add(CreateTapGesture(PageType.Audits));
            btnTasks.GestureRecognizers.Add(CreateTapGesture(PageType.Tasks));
            btnProjects.GestureRecognizers.Add(CreateTapGesture(PageType.Projects));
            btnProfile.GestureRecognizers.Add(CreateTapGesture(PageType.Profile));
            btnSettings.GestureRecognizers.Add(CreateTapGesture(PageType.Settings));
            btnUpdating.GestureRecognizers.Add(CreateTapGesture(PageType.Updating));
            btnHelp.GestureRecognizers.Add(CreateTapGesture(PageType.Help));
            btnExit.GestureRecognizers.Add(CreateTapGesture(PageType.Exit));
        }
        private IGestureRecognizer CreateTapGesture(PageType audits)
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) =>
            {
                PageSelected?.Invoke(this, audits);
            };
            return tap;
        }
    }
}