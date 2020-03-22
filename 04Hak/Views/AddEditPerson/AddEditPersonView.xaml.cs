using System.Windows.Controls;
using KMACSharp04Hak.Tools.Navigation;
using KMACSharp04Hak.ViewModels.AddEditPerson;

namespace KMACSharp04Hak.Views.AddEditPerson
{
    public partial class AddEditPersonView : UserControl, INavigatable
    {
        public AddEditPersonView()
        {
            InitializeComponent();
            DataContext = new AddEditPersonViewModel();
        }
    }
}