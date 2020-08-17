using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PancakeView;

namespace medExpert.ViewModels.Audits
{
    public class CheckListDetailViewModel
    {
        public DashPattern BorderDashPattern { get; set; } = new DashPattern(10, 5, 2, 5);
    }
}
