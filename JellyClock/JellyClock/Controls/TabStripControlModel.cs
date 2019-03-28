using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using JellyClock.Views;
using Prism.Mvvm;
using Xamarin.Forms;

namespace TabStrip.FormsPlugin.Abstractions
{
    public class TabStripControlModel : BindableBase
    {
        public TabStripControlModel()
        {
            Tabs  = new ObservableCollection<TabModel>();
            TabPosition = 0;
            SlideTab = new Command<string>(OnSlideTab);
            SlideToTab = new Command<string>(OnSlideToTab);
            Tests = new ObservableCollection<string> { "1", "2", "3" };
            Title = "Hello";
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        private ObservableCollection<string> vs;
        public ObservableCollection<string> Tests
        {
            get { return vs; }
            set { SetProperty(ref vs, value); }
        }


        public ICommand SlideTab { get; set; }
        public ICommand SlideToTab { get; set; }

        private bool _hasNext;
        public bool HasNext
        {
            get { return _hasNext; }
            set
            {
                _hasNext = value;
                RaisePropertyChanged(nameof(HasNext));
            }
        }

        private bool _hasPrevious;
        public bool HasPrevious
        {
            get { return _hasPrevious; }
            set
            {
                _hasPrevious = value;
                RaisePropertyChanged(nameof(HasPrevious));
            }
        }

        private ObservableCollection<TabModel> _tabs;
        public ObservableCollection<TabModel> Tabs
        {
            get { return _tabs; }
                set { SetProperty(ref _tabs, value); }
        }

        private int _tabPosition;
        public int TabPosition
        {
            get { return _tabPosition; }
            set
            {
                _tabPosition = value;
                HasPrevious = TabPosition > 0;
                HasNext = TabPosition < Tabs.Count - 1;
                RaisePropertyChanged(nameof(TabPosition));
            }
        }

        private void OnSlideTab(string direction)
        {
            var tabModifier = int.Parse(direction);
            TabPosition += tabModifier;
        }

        private void OnSlideToTab(string position)
        {
            TabPosition = int.Parse(position);
        }
    }
}
