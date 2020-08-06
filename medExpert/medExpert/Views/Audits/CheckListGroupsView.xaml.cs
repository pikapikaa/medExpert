using medExpert.ViewModels.Audits;
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
    public partial class CheckListGroupsView : ContentPage
    {
        public CheckListGroupsView()
        {
            InitializeComponent();
            BindingContext = new CheckListGroupsViewModel()
            {
                Navigation = this.Navigation
            };
        }

        private void treeView_QueryNodeSize(object sender, Syncfusion.XForms.TreeView.QueryNodeSizeEventArgs e)
        {
            e.Height = e.GetActualNodeHeight();
            e.Handled = true;
        }
    }
}