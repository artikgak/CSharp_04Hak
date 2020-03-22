using System;
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
        private DateTime _date;
        #endregion

        #region Commands
        private RelayCommand<object> _submitCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion

        internal AddEditPersonViewModel(Person person)
        {
            _person = person;
            _name = person.Name;
            _surname = person.Surname;
            _email = person.Email;
            _date = person.BirthDate;
        }

        internal AddEditPersonViewModel(){}

        public RelayCommand<object> Cancel
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand =
                           new RelayCommand<object>(o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.Main);
                           }));
            }
        }

        public RelayCommand<object> Submit
        {
            get
            {
                return _submitCommand ?? (_submitCommand =
                           new RelayCommand<object>(o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.Main);
                           }));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
            }
        }
    }
}
