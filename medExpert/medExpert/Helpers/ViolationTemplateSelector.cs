using Syncfusion.TreeView.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace medExpert.Helpers
{
    public class ViolationTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeaderTemplate { get; set; }
        public DataTemplate ChildTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var treeviewNode = item as TreeViewNode;
            if (treeviewNode == null)
                return null;
            if (treeviewNode.Level == 0)
                return HeaderTemplate;
                return ChildTemplate;
        }
    }
}
