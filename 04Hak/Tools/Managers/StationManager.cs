using KMACSharp04Hak.Models;
using KMACSharp04Hak.Tools.DataStorage;

namespace KMACSharp04Hak.Tools.Managers
{
    internal class StationManager
    {
        private static readonly object Locker = new object();
        private static StationManager _instance;

        private IDataStorage _dataStorage;

        internal static StationManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (Locker)
                {
                    return _instance ?? (_instance = new StationManager());
                }
            }
        }

        internal Person SelectedPerson { get; set; }

        internal IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        private StationManager()
        {
        }

        internal void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }
    }
}