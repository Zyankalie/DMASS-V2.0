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
        public Tab SelectedTab;
        private List<BaseViewModel> models;
        public MainWindowViewModel()
        {
            //NewAuthorTabCommand = new ActionCommand(p => NewAuthorTab());
            NewAuthorListTabCommand = new ActionCommand(p => NewAuthorListTab());
            //NewDocumentTabCommand = new ActionCommand(p => NewDocumentTab());
            NewDocumentListTabCommand = new ActionCommand(p => NewDocumentListTab());
            //NewAuthorTabCommandParams = new ActionCommand(p => NewAuthorTab());

            models = new List<BaseViewModel>();
            tabs = new ObservableCollection<Tab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;

            Tabs = tabs;
        }


        public ICommand NewTabCommand { get; }
        public ICommand NewAuthorTabCommand { get; }
        public ICommand NewAuthorTabCommandParams { get; }
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
            AuthorListTabViewModel altvm = new AuthorListTabViewModel() { Parent = this };
            AuthorListTabView view = new AuthorListTabView();

            Tab AuthorListTab = new AuthorListTab() { Content = view, DataContext = altvm };
            AuthorListTab.IsSelected = true;
            models.Add(altvm);
            this.SelectedTab = AuthorListTab;
            Tabs.Add(AuthorListTab);
        }

        public void NewAuthorListTab(string FirstName, string LastName, BaseViewModel bmv)
        {
            Tabs.Remove(SelectedTab);
            models.Remove(bmv);

            AuthorListTabViewModel altvm = new AuthorListTabViewModel(FirstName, LastName) { Parent = this };
            AuthorListTabView view = new AuthorListTabView();

            Tab AuthorListTab = new AuthorListTab() { Content = view, DataContext = altvm };
            AuthorListTab.IsSelected = true;
            SelectedTab = AuthorListTab;
            models.Add(altvm);

            Tabs.Add(AuthorListTab);
        }

        public void NewAuthorTab(string FirstName, string LastName, BaseViewModel bmv, SmallAuthorObject SmallAuthorObject)
        {
            Tabs.Remove(SelectedTab);
            models.Remove(bmv);

            AuthorTabViewModel atvm = new AuthorTabViewModel(FirstName, LastName, SmallAuthorObject, this);
            AuthorTabView view = new AuthorTabView();

            Tab AuthorTab = new AuthorTab(SmallAuthorObject.FirstName + " " + SmallAuthorObject.LastName) { Content = view, DataContext = atvm };
            AuthorTab.IsSelected = true;
            SelectedTab = AuthorTab;
            models.Add(atvm);

            Tabs.Add(AuthorTab);
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
