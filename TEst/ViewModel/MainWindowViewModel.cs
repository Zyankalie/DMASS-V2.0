using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace DMASS
{
    public class MainWindowViewModel
    {
        private readonly ObservableCollection<Tab> tabs;
        private List<BaseViewModel> models;
        public MainWindowViewModel()
        {
            NewAuthorTabCommand = new ActionCommand(p => NewAuthorTab());
            NewAuthorListTabCommand = new ActionCommand(p => NewAuthorListTab());
            NewDocumentTabCommand = new ActionCommand(p => NewAuthorTab());
            NewDocumentListTabCommand = new ActionCommand(p => NewDocumentListTab());

            models = new List<BaseViewModel>();            
            tabs = new ObservableCollection<Tab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;

            Tabs = tabs;
        }


        public ICommand NewTabCommand { get; }
        public ICommand NewAuthorTabCommand { get; }
        public ICommand NewAuthorListTabCommand { get; }
        public ICommand NewDocumentTabCommand { get; }
        public ICommand NewDocumentListTabCommand { get; }
        public ICollection<Tab> Tabs { get; }

        private void NewDocumentListTab()
        {
            Tabs.Add(new DocumentListTab());
        }
        private void NewAuthorListTab()
        {
            AuthorListTabViewModel altvm = new AuthorListTabViewModel();
            models.Add(altvm);
            AuthorListTabView view = new AuthorListTabView();
            Tabs.Add(new AuthorListTab() { Content = view, DataContext = altvm} );                        
        }

        private void NewAuthorTab()
        {
            Tabs.Add(new AuthorTab());
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Tab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (Tab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (Tab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            Tabs.Remove((Tab)sender);
            models.Remove((BaseViewModel)(((Tab)sender).DataContext));
            
        }
    }
}
