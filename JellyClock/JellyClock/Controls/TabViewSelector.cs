using System.Collections.Generic;
using JellyClock.Views;
using Xamarin.Forms;

namespace TabStrip.FormsPlugin.Abstractions
{
    internal class TabViewSelector : DataTemplateSelector
    {
        public TabViewSelector()
        {
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {            
            var tab = item.ToString();
            return new DataTemplate(typeof(HelloView));
        }
    }
}
