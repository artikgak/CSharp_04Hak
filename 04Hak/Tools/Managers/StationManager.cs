using KMACSharp04Hak.Models;
using KMACSharp04Hak.Tools.DataStorage;

namespace KMACSharp04Hak.Tools.Managers
{
    internal static class StationManager
    {

        private static IDataStorage _dataStorage;
        private static Person _selectedPerson;

        internal static Person SelectedPerson { get; set; }

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

    }
}
