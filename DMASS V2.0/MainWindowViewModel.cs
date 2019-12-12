namespace DMASS_V2._0
{
    using DMASS_V2._0.Controller;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    public class MainWindowViewModel
    {
        private readonly ObservableCollection<CustomTab> tabs;
        public MainWindowViewModel()
        {
            NewTabCommand = new ActionCommand(p => NewTab());

            tabs = new ObservableCollection<CustomTab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;

            Tabs = tabs;
        }

        public ICommand NewTabCommand { get; }
        public ICollection<CustomTab> Tabs { get; }

        private void NewTab()
        {
            
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CustomTab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (CustomTab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (CustomTab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            Tabs.Remove((CustomTab)sender);
        }
    }
}
