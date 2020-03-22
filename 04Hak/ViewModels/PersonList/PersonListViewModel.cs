using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using KMACSharp04Hak.Models;
using KMACSharp04Hak.Tools;
using KMACSharp04Hak.Tools.DataStorage;
using KMACSharp04Hak.Tools.Managers;
using KMACSharp04Hak.Tools.MVVM;
using KMACSharp04Hak.Tools.Navigation;

namespace KMACSharp04Hak.ViewModels.PersonList
{
    internal class PersonListViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Person> _persons;

        #endregion

        #region Commands

        private RelayCommand<object> _addPersonCommand;
        private RelayCommand<object> _editPersonCommand;
        private RelayCommand<object> _deletePersonCommand;

        private RelayCommand<object> _sortNameCommand;
        private RelayCommand<object> _sortSurnameCommand;
        private RelayCommand<object> _sortEmailCommand;
        private RelayCommand<object> _sortBirthdateCommand;
        private RelayCommand<object> _sortSunSignCommand;
        private RelayCommand<object> _sortChineseSignCommand;
        private RelayCommand<object> _sortIsAdultCommand;
        private RelayCommand<object> _sortIsBirthdayCommand;

        #endregion

        internal PersonListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.Instance.DataStorage.PersonList);
        }

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }

            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }


        public Person SelectedPerson
        {
            private get { return StationManager.Instance.SelectedPerson; }

            set
            {
                StationManager.Instance.SelectedPerson = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> AddPerson
        {
            get
            {
                return _addPersonCommand ?? (_addPersonCommand =
                    new RelayCommand<object>(
                        o => { NavigationManager.Instance.Navigate(ViewType.AddEditPerson); }));
            }
        }

        public RelayCommand<object> EditPerson
        {
            get
            {
                return _editPersonCommand ?? (_editPersonCommand =
                    new RelayCommand<object>(
                        o => { NavigationManager.Instance.Navigate(ViewType.AddEditPerson); }));
            }
        }

        public RelayCommand<object> DeletePerson
        {
            get
            {
                return _deletePersonCommand ?? (_deletePersonCommand =
                    new RelayCommand<object>(
                        DeletePersonMethod, o => CanExecuteCommand()
                    ));
            }
        }

        void DeletePersonMethod(object obj)
        {
            StationManager.Instance.DataStorage.DeletePerson(SelectedPerson);
        }

        bool CanExecuteCommand()
        {
            return SelectedPerson != null;
        }

        #region SortProperties

        public RelayCommand<object> SortName
        {
            get
            {
                return _sortNameCommand ?? (_sortNameCommand = new RelayCommand<object>(o =>
                    SortImplementation(o, 1)));
            }
        }

        public RelayCommand<object> SortSurname
        {
            get
            {
                return _sortSurnameCommand ?? (_sortSurnameCommand = new RelayCommand<object>(o =>
                    SortImplementation(o, 2)));
            }
        }

        public RelayCommand<object> SortEmail
        {
            get
            {
                return _sortEmailCommand ?? (_sortEmailCommand = new RelayCommand<object>(o =>
                    SortImplementation(o, 3)));
            }
        }

        public RelayCommand<object> SortBirthdate
        {
            get
            {
                return _sortBirthdateCommand ?? (_sortBirthdateCommand = new RelayCommand<object>(o =>
                    SortImplementation(o, 4)));
            }
        }

        public RelayCommand<object> SortSunSign
        {
            get
            {
                return _sortSunSignCommand ?? (_sortSunSignCommand = new RelayCommand<object>(o =>
                    SortImplementation(o, 5)));
            }
        }

        public RelayCommand<object> SortChineseSign
        {
            get
            {
                return _sortChineseSignCommand ?? (_sortChineseSignCommand = new RelayCommand<object>(o =>
                    SortImplementation(o, 6)));
            }
        }

        public RelayCommand<object> SortIsAdult
        {
            get
            {
                return _sortIsAdultCommand ?? (_sortIsAdultCommand = new RelayCommand<object>(o =>
                    SortImplementation(o, 7)));
            }
        }

        public RelayCommand<object> SortIsBirthday
        {
            get
            {
                return _sortIsBirthdayCommand ?? (_sortIsBirthdayCommand = new RelayCommand<object>(o =>
                    SortImplementation(o, 8)));
            }
        }

        #endregion

        private async void SortImplementation(object obj, int i)
        {
            await Task.Run(() =>
            {
                IOrderedEnumerable<Person> sortedPersons;
                switch (i)
                {
                    case 1:
                        sortedPersons = from u in _persons
                            orderby u.Name
                            select u;
                        break;
                    case 2:
                        sortedPersons = from u in _persons
                            orderby u.Surname
                            select u;
                        break;
                    case 3:
                        sortedPersons = from u in _persons
                            orderby u.Email
                            select u;
                        break;
                    case 4:
                        sortedPersons = from u in _persons
                            orderby u.BirthDate
                            select u;
                        break;
                    case 5:
                        sortedPersons = from u in _persons
                            orderby u.SunSign
                            select u;
                        break;
                    case 6:
                        sortedPersons = from u in _persons
                            orderby u.ChineseSign
                            select u;
                        break;
                    case 7:
                        sortedPersons = from u in _persons
                            orderby u.IsAdult
                            select u;
                        break;
                    default:
                        sortedPersons = from u in _persons
                            orderby u.IsBirthday
                            select u;
                        break;
                }

                Persons = new ObservableCollection<Person>(sortedPersons);
            });
        }
    }
}