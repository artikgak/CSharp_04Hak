using System.Collections.Generic;
using System.Collections.ObjectModel;
using KMACSharp04Hak.Models;

namespace KMACSharp04Hak.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool AddPerson(Person person);
        bool EditPerson(ref Person toEditPerson,  Person changedPerson);
        bool DeletePerson( Person person);
        ObservableCollection<Person> PersonList { get; }
    }
}   
