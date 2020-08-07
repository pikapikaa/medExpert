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
    public partial class AuditOperationRecordView : ContentPage
    {
        public AuditOperationRecordView()
        {
            InitializeComponent();
            BindingContext = new AuditOperationRecordViewModel()
            {
                Navigation = this.Navigation
            };
        }
    }
}