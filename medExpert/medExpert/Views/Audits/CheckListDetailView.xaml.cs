using medExpert.ViewModels.Audits;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace medExpert.Views.Audits
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckListDetailView : ContentPage
    {
        public CheckListDetailView()
        {
            InitializeComponent();
            BindingContext = new CheckListDetailViewModel()
            {
                Navigation = this.Navigation
            };
            this.SizeChanged += CheckListDetailView_SizeChanged;
        }

        private void CheckListDetailView_SizeChanged(object sender, EventArgs e)
        {
            double width = Width / 4.2;
            cropView1.HeightRequest = cropView1.WidthRequest = width;
            cropView2.HeightRequest = cropView2.WidthRequest = width;
            cropView3.HeightRequest = cropView3.WidthRequest = width;
            cropView4.HeightRequest = cropView4.WidthRequest = width;
        }

        private void takePhoto_Clicked(object sender, EventArgs e)
        {

        }

        private void treeView1_QueryNodeSize(object sender, Syncfusion.XForms.TreeView.QueryNodeSizeEventArgs e)
        {
            e.Height = e.GetActualNodeHeight();
            e.Handled = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}