using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMASS
{
    public class MainWindowViewModel
    {
        private readonly ObservableCollection<ITab> tabs;
        private AuthorListTabViewModel altvm;
        public MainWindowViewModel()
        {
            NewAuthorTabCommand = new ActionCommand(p => NewAuthorTab());
            NewAuthorListTabCommand = new ActionCommand(p => NewAuthorListTab());
            NewDocumentTabCommand = new ActionCommand(p => NewAuthorTab());
            NewDocumentListTabCommand = new ActionCommand(p => NewDocumentListTab());

            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;

            Tabs = tabs;
        }


        public ICommand NewTabCommand { get; }
        public ICommand NewAuthorTabCommand { get; }
        public ICommand NewAuthorListTabCommand { get; }
        public ICommand NewDocumentTabCommand { get; }
        public ICommand NewDocumentListTabCommand { get; }
        public ICollection<ITab> Tabs { get; }

        private void NewDocumentListTab()
        {
            Tabs.Add(new DocumentListTab());
        }
        private void NewAuthorListTab()
        {

            altvm = new AuthorListTabViewModel();

            AuthorListTabView view = new AuthorListTabView();
            Tabs.Add(new AuthorListTab() { Content = view, DataContext = altvm });


        }

        private void NewAuthorTab()
        {
            Tabs.Add(new AuthorTab());
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ITab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (ITab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            Tabs.Remove((ITab)sender);
        }
    }

    enum TabKind
    {
        AuthorTab,
        AuthorListTab,
        DocumentTab,
        DocumentListTab
    }
}
