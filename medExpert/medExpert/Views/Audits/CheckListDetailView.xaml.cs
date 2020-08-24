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