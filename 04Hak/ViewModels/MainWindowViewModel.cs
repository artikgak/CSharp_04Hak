using System;
using System.Windows;
using KMACSharp04Hak.Tools;
using KMACSharp04Hak.Tools.DataStorage;
using KMACSharp04Hak.Tools.Managers;
using KMACSharp04Hak.Tools.Navigation;
using KMACSharp04Hak.ViewModels.PersonList;

namespace KMACSharp04Hak.ViewModels
{
    internal class MainWindowViewModel: BaseViewModel, IContentOwner
    {
        private INavigatable _content;
        public INavigatable Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
        internal MainWindowViewModel()
        {
            StationManager.Instance.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new AddEditPersonNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);
        }
    }
}
