using System;
using System.Windows;
using KMACSharp04Hak.Models;
using KMACSharp04Hak.Tools;
using KMACSharp04Hak.Tools.Managers;
using KMACSharp04Hak.Tools.MVVM;
using KMACSharp04Hak.Tools.Navigation;

namespace KMACSharp04Hak.ViewModels.AddEditPerson
{
    class AddEditPersonViewModel : BaseViewModel
    {
        #region Fields

        private Person _person;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date = DateTime.Today;

        #region Commands
        private RelayCommand<object> _submitCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion

        #endregion

        #region Constructors

        internal AddEditPersonViewModel(Person person)
        {
            _person = person;
            _name = person.Name;
            _surname = person.Surname;
            _email = person.Email;
            _date = person.BirthDate;
        }

        internal AddEditPersonViewModel()
        { }

        #endregion

        #region Properties

        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; 
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value; 
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region CommandProperties

        public RelayCommand<object> Cancel
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand =
                    new RelayCommand<object>(o => { NavigationManager.Instance.Navigate(ViewType.Main); }));
            }
        }

        public RelayCommand<object> Submit
        {
            get
            {
                return _submitCommand ?? (_submitCommand =
                    new RelayCommand<object>(o => { SubmitChanges(_person); }));
            }
        }

        #endregion

        private void SubmitChanges(object obj)
        {
            try
            {
                if (Person == null)
                {
                    var newPerson = new Person(Name, Surname, Email,
                        Date);
                    StationManager.Instance.DataStorage.AddPerson(newPerson);
                    NavigationManager.Instance.Navigate(ViewType.Main);
                }
                else
                {
                    Person newPerson = new Person(Name, Surname, Email,
                        Date);
                    StationManager.Instance.DataStorage.EditPerson(_person, newPerson);
                    NavigationManager.Instance.Navigate(ViewType.Main);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}