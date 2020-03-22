using System.Windows.Controls;
using KMACSharp04Hak.Tools.DataStorage;
using KMACSharp04Hak.Tools.Managers;
using KMACSharp04Hak.Tools.Navigation;
using KMACSharp04Hak.ViewModels.PersonList;

namespace KMACSharp04Hak.Views.PersonList
{
    /// <summary>
    /// Interaction logic for PersonList.xaml
    /// </summary>
    internal partial class PersonList : UserControl, INavigatable
    {
        internal PersonList()
        {
            InitializeComponent();
#if DEBUG
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;
#endif
            StationManager.Instance.Initialize(new SerializedDataStorage());
            DataContext = new PersonListViewModel();
        }
    }
}
