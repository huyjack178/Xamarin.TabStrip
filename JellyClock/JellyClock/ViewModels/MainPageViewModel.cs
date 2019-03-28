using JellyClock.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TabStrip.FormsPlugin.Abstractions;
using Xamarin.Forms;

namespace JellyClock.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Data = new ObservableCollection<TabModel>(new[]
          {
                    new TabModel
                    {
                        Header = new Tuple<View, object>(new HeaderView(), new { Title = "Tab 1" }),
                        View = new Tuple<View, object>(new HelloView(), new { Message = "Tab Strip 1" })
                    },
                    new TabModel
                    {
                        Header = new Tuple<View, object>(new HeaderView(), new { Title = "Tab 2" }),
                        View = new Tuple<View, object>(new HelloView(), new { Message = "Tab Strip 2" })
                    },
                    new TabModel
                    {
                        Header = new Tuple<View, object>(new HeaderView(), new { Title = "Tab 3" }),
                        View = new Tuple<View, object>(new HelloView(), new { Message = "Tab Strip 3" })
                    },
                    new TabModel
                    {
                        Header = new Tuple<View, object>(new HeaderView(), new { Title = "Tab 4" }),
                        View = new Tuple<View, object>(new HelloView(), new { Message = "Tab Strip 4" })
                    },
                    new TabModel
                    {
                        Header = new Tuple<View, object>(new HeaderView(), new { Title = "Tab 5" }),
                        View = new Tuple<View, object>(new HelloView(), new { Message = "Tab Strip 5" })
                    }
                });
            Position = 2;
            Title = "This is a test title";

        Tests = new ObservableCollection<string> { "1", "2", "3" };
        }

        private ObservableCollection<string> vs;
        public ObservableCollection<string> Tests
        {
            get { return vs; }
            set { SetProperty(ref vs, value); }
        }

public int Position { get; set; }
        public ObservableCollection<TabModel> Data { get; set; }
    }
}
