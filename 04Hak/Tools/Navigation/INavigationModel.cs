namespace KMACSharp04Hak.Tools.Navigation
{
    internal enum ViewType
    {
        Main = 0,
        AddEditPerson = 1,
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
