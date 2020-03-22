using System.Collections.Generic;
using KMACSharp04Hak.Models;

namespace KMACSharp04Hak.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddPerson(Person person);
        void EditPerson(ref Person toEditPerson, ref Person changedPerson);
        void DeletePerson(ref Person person);
        List<Person> PersonList { get; }
    }
}   
