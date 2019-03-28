using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using CarouselView.FormsPlugin.Abstractions;
using JellyClock.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabStrip.FormsPlugin.Abstractions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabStripControl : ContentView
    {
        public TabStripControlModel ViewModel { get; set; }
        public TabStripControl()
        {
            InitializeComponent();
            ViewModel = new TabStripControlModel();
            Carousel.BindingContext = ViewModel;
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
                "ItemsSource",
                typeof(IEnumerable),
                typeof(TabStripControl),
                null,
                propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (TabStripControl)bindable;

            if (control != null)
            {
                var tabs = (IEnumerable<TabModel>)newValue;
                control.ViewModel.Tabs = new ObservableCollection<TabModel>(tabs);
            }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
    }
}