using medExpert.ViewModels.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace medExpert.Views.Tasks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksView : ContentPage
    {
        public TasksView()
        {
            InitializeComponent();
            BindingContext = new TasksViewModel();
        }
    }
}