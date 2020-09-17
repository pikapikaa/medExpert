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
    public partial class TaskDetailView : ContentPage
    {
        public TaskDetailView()
        {
            InitializeComponent();
            SizeChanged += CheckListDetailView_SizeChanged;
        }

        private void CheckListDetailView_SizeChanged(object sender, EventArgs e)
        {
            double width = Width / 4.2;
            cropView1.HeightRequest = cropView1.WidthRequest = width;
            cropView2.HeightRequest = cropView2.WidthRequest = width;
            cropView3.HeightRequest = cropView3.WidthRequest = width;
            cropView4.HeightRequest = cropView4.WidthRequest = width;
        }
    }
}