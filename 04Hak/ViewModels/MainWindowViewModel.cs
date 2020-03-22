using System.Windows;
using KMACSharp04Hak.Tools;
using KMACSharp04Hak.Tools.DataStorage;
using KMACSharp04Hak.Tools.Managers;
using KMACSharp04Hak.Tools.Navigation;

namespace KMACSharp04Hak.ViewModels
{
    internal class MainWindowViewModel: BaseViewModel, IContentOwner, ILoaderOwner
    {

        #region Fields
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

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
            LoaderManager.Instance.Initialize(this);
            StationManager.Instance.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new AddEditPersonNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);
        }
    }
}
