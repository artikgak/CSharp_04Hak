using KMACSharp04Hak.Tools.DataStorage;

namespace KMACSharp04Hak.Tools.Managers
{
    internal static class StationManager
    {
        private static IDataStorage _dataStorage;

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
