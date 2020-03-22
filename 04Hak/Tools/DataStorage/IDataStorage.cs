using System.Collections.ObjectModel;
using KMACSharp04Hak.Models;

namespace KMACSharp04Hak.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddPerson(Person person);
        void EditPerson(Person toEditPerson,  Person changedPerson);
        void DeletePerson(Person person);
        ObservableCollection<Person> PersonList { get; }
    }
}   
